using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum_api.Repositories;
using Moq;
using forum_api.DataAccess.DataObjects;
using forum_api.Exceptions;

namespace forum_api.Services.Tests
{
    [TestClass()]
    public class TopicServiceTests
    {
        private ITopicService _topicService;
        private Mock<ITopicRepository> _topicRepository;
        private Topic expectedTopic;

        [TestInitialize]
        public void Initialize()
        {
            this._topicRepository = new Mock<ITopicRepository>();
            this._topicService = new TopicService(this._topicRepository.Object);

            this.expectedTopic = new Topic()
            {
                Id = 1,
                CreationDate = DateTime.Now,
                ModificationDate = null,
                Title = "Test",
                Author = "Thomas",
                Comments = new List<Comment>()
            };
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void GetTopicByIdTest_ParamsOk_ShouldReturnTopic(int id)
        {
            // Arrange
            this._topicRepository.Setup(repo => repo.GetTopicById(It.IsAny<int>())).Returns(this.expectedTopic);

            // Act
            Topic actualTopic = _topicService.GetTopicById(id);

            // Assert
            Assert.IsInstanceOfType(actualTopic, typeof(Topic));
            Assert.AreEqual(expectedTopic, actualTopic);
            this._topicRepository.VerifyAll();
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void GetTopicByIdTest_InvalidId_ShouldThrowNotFoundException(int id)
        {
            // Arrange
            this._topicRepository.Setup(r => r.GetTopicById(It.IsAny<int>()))
                .Returns((Topic)null);

            // Act + Assert
            Assert.ThrowsException<NotFoundException>(() => _topicService.GetTopicById(id));
            this._topicRepository.VerifyAll();
        }

        [TestMethod()]
        public void GetTopicsTest_ParamsOk_ShouldReturnList()
        {
            // Arrange
            List<Topic> expectedTopics = new List<Topic>() { expectedTopic, expectedTopic };
            this._topicRepository.Setup(r => r.GetTopics()).Returns(expectedTopics);

            // Act
            var actualTopics = _topicService.GetTopics();

            // Assert
            Assert.IsInstanceOfType(actualTopics, typeof(List<Topic>));
            Assert.AreEqual(expectedTopics, actualTopics);
            this._topicRepository.VerifyAll();
        }

        //[TestMethod()]
        //public void CreateTopicTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void UpdateTopicTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DeleteTopicTest()
        //{
        //    Assert.Fail();
        //}
    }
}
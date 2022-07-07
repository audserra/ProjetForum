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


        private IWordFilterService _wordFilterService;

        private static DateTime originDate = new DateTime(2000, 08, 07, 09, 05, 00);

        private static IEnumerable<Topic[]> GetTestData()
        {
            return new List<Topic[]>
            {
                    new Topic[]
                    {
                        new Topic(){
                            Id = 1,
                            CreationDate = originDate,
                            ModificationDate = originDate,
                            Title = "Test",
                            Author = "Thomas",
                            Comments = new List<Comment>() }
                    },
                    new Topic[]
                    {
                        new Topic(){
                            Id = 2,
                            CreationDate = originDate,
                            ModificationDate = originDate,
                            Title = "Test",
                            Author = "Audrey",
                            Comments = new List<Comment>() }
                    }
            };
        }

        [TestInitialize]
        public void Initialize()
        {
            this._wordFilterService = new WordFilterService();
            this._topicRepository = new Mock<ITopicRepository>();
            this._topicService = new TopicService(this._topicRepository.Object, this._wordFilterService);

            this.expectedTopic = new Topic()
            {
                Id = 1,
                CreationDate = originDate,
                ModificationDate = null,
                Title = "Test",
                Author = "Thomas",
                Comments = new List<Comment>()
            };
        }

        [TestMethod()]
        [DataRow(1)]
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



        [TestMethod()]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void CreateTopicTest_ParamsOk_ShouldCreateTopic(Topic topic)
        {
            // Arrange
            this._topicRepository.Setup(r => r.AddTopic(It.IsAny<Topic>())).Returns(topic);

            // Act
            var actualTopic = _topicService.AddTopic(topic);

            // Assert
            Assert.IsInstanceOfType(actualTopic, typeof(Topic));
            Assert.AreEqual(topic, actualTopic);
            Assert.AreNotEqual(actualTopic.CreationDate, originDate);
            this._topicRepository.VerifyAll();
        }

        [TestMethod()]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void UpdateTopicTest_paramsOk_ShouldUpdateModificationDateAndUpdateTopic(Topic topic)
        {
            // Arrange
            this._topicRepository.Setup(r => r.UpdateTopic(It.IsAny<Topic>()))
                .Returns(topic);

            // Act
            var actualTopic = _topicService.UpdateTopic(topic);

            // Assert
            Assert.IsInstanceOfType(actualTopic, typeof(Topic));
            Assert.AreEqual(topic, actualTopic);
            Assert.AreEqual(originDate, actualTopic.CreationDate);
            Assert.AreNotEqual(originDate, actualTopic.ModificationDate);
            this._topicRepository.VerifyAll();
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void DeleteTopicTest_ValidId_ShouldDeleteTopic(int id)
        {
            // Arrange
            this._topicRepository.Setup(r => r.GetTopicById(It.IsAny<int>())).Returns(this.expectedTopic);

            this._topicRepository.Setup(r => r.DeleteTopic(It.IsAny<int>()));

            // Act
            _topicService.DeleteTopic(id);

            // Assert
            this._topicRepository.VerifyAll();
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void DeleteTopicTest_InvalidId_ShouldThrowNotFoundException(int id)
        {
            // Arrange
            this._topicRepository.Setup(r => r.GetTopicById(It.IsAny<int>()))
                .Returns((Topic)null);

            // Act + Assert
            Assert.ThrowsException<NotFoundException>(() => _topicService.DeleteTopic(id));
            this._topicRepository.VerifyAll();
        }
    }
}
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
    public class CommentServiceTests
    {
        private ICommentService _commentService;
        private Mock<ICommentRepository> _commentRepository;

        private ITopicService _topicService;
        private Mock<ITopicRepository> _topicRepository;

        private Comment expectedComment;
        private DateTime originDateTime;

        [TestInitialize]
        public void Initialize()
        {
            this._topicRepository = new Mock<ITopicRepository>(MockBehavior.Strict);
            this._topicService = new TopicService(this._topicRepository.Object);

            this._commentRepository = new Mock<ICommentRepository>(MockBehavior.Strict);
            this._commentService = new CommentService(this._commentRepository.Object, this._topicService);


            this.originDateTime = new DateTime(1970, 1, 1);
            this.expectedComment = new Comment()
            {
                Id = 1,
                User = Guid.NewGuid().ToString(),
                CreationDate = originDateTime,
                ModificationDate = originDateTime,
                Content = Guid.NewGuid().ToString(),
                TopicId = 1
            };
        }
        
        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void GetCommentByIdTest_ValidId_ShouldReturnComment(int id)
        {
            // Arrange
            this._commentRepository.Setup(r => r.GetCommentById(It.IsAny<int>()))
                .Returns(this.expectedComment);

            // Act
            var actualComment = _commentService.GetCommentById(id);

            // Assert
            Assert.IsInstanceOfType(actualComment, typeof(Comment));
            Assert.AreEqual(expectedComment, actualComment);
            this._commentRepository.VerifyAll();
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void GetCommentByIdTest_InvalidId_ShouldThrowNotFoundException(int id)
        {
            // Arrange
            this._commentRepository.Setup(r => r.GetCommentById(It.IsAny<int>()))
                .Returns((Comment)null);

            // Act + Assert
            Assert.ThrowsException<NotFoundException>(() => _commentService.GetCommentById(id));
            this._commentRepository.VerifyAll();
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void GetCommentsByTopicIdTest_ValidTopicId_ShouldReturnList(int id)
        {
            // Arrange
            this._topicRepository.Setup(r => r.GetTopicById(It.IsAny<int>()))
                .Returns(new Topic());

            this._commentRepository.Setup(r => r.GetCommentsByTopicId(It.IsAny<int>()))
                .Returns(new List<Comment>() { expectedComment, expectedComment});

            // Act
            var actualComments = _commentService.GetCommentsByTopicId(id);

            // Assert
            Assert.IsInstanceOfType(actualComments, typeof(List<Comment>));
            Assert.AreEqual(2, actualComments.Count);
            this._commentRepository.VerifyAll();
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void GetCommentsByTopicIdTest_InvalidTopicId_ShouldThrowNotFoundException(int id)
        {
            // Arrange
            this._topicRepository.Setup(r => r.GetTopicById(It.IsAny<int>()))
                .Returns((Topic)null);

            // Act + Assert
            Assert.ThrowsException<NotFoundException>(() => _commentService.GetCommentsByTopicId(id));
            this._commentRepository.VerifyAll();
        }

        [TestMethod()]
        public void CreateCommentTest_ValidInput_ShouldUpdateCreationDateAndAddComment()
        {
            // Arrange
            this._topicRepository.Setup(r => r.GetTopicById(It.IsAny<int>()))
                .Returns(new Topic());

            this._commentRepository.Setup(r => r.CreateComment(It.IsAny<Comment>()))
                .Returns(expectedComment);

            // Act
            var actualComment = _commentService.CreateComment(expectedComment);

            // Assert
            Assert.IsInstanceOfType(actualComment, typeof(Comment));
            Assert.AreEqual(expectedComment, actualComment);
            Assert.AreNotEqual(originDateTime, actualComment.CreationDate);
            this._commentRepository.VerifyAll();
        }

        [TestMethod()]
        public void CreateCommentTest_InvalidTopicId_ShouldThrowNotFoundException()
        {
            // Arrange
            this._topicRepository.Setup(r => r.GetTopicById(It.IsAny<int>()))
                .Returns((Topic)null);

            // Act + Assert
            Assert.ThrowsException<NotFoundException>(() => _commentService.CreateComment(expectedComment));
            this._commentRepository.VerifyAll();
        }


        [TestMethod()]
        public void UpdateCommentTest_ValidInput_ShouldUpdateModificationDateAndUpdateComment()
        {
            // Arrange
            this._topicRepository.Setup(r => r.GetTopicById(It.IsAny<int>()))
                .Returns(new Topic());

            this._commentRepository.Setup(r => r.UpdateComment(It.IsAny<Comment>()))
                .Returns(expectedComment);

            // Act
            var actualComment = _commentService.UpdateComment(expectedComment);

            // Assert
            Assert.IsInstanceOfType(actualComment, typeof(Comment));
            Assert.AreEqual(expectedComment, actualComment);
            Assert.AreEqual(originDateTime, actualComment.CreationDate);
            Assert.AreNotEqual(originDateTime, actualComment.ModificationDate);
            this._commentRepository.VerifyAll();
        }

        [TestMethod()]
        public void UpdateCommentTest_InvalidTopicId_ShouldThrowNotFoundException()
        {
            // Arrange
            this._topicRepository.Setup(r => r.GetTopicById(It.IsAny<int>()))
                .Returns((Topic)null);

            // Act + Assert
            Assert.ThrowsException<NotFoundException>(() => _commentService.UpdateComment(expectedComment));
            this._commentRepository.VerifyAll();
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void DeleteCommentTest_ValidId_ShouldDeleteComment(int id)
        {
            // Arrange
            this._commentRepository.Setup(r => r.GetCommentById(It.IsAny<int>()))
                .Returns(this.expectedComment);

            this._commentRepository.Setup(r => r.DeleteComment(It.IsAny<int>()));

            // Act
            _commentService.DeleteComment(id);

            // Assert
            this._commentRepository.VerifyAll();
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void DeleteCommentTest_InvalidId_ShouldThrowNotFoundException(int id)
        {
            // Arrange
            this._commentRepository.Setup(r => r.GetCommentById(It.IsAny<int>()))
                .Returns((Comment)null);

            // Act + Assert
            Assert.ThrowsException<NotFoundException>(() => _commentService.DeleteComment(id));
            this._commentRepository.VerifyAll();
        }



    }
}
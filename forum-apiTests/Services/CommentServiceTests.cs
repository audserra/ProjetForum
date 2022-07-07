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
        private Comment expectedComment;

        [TestInitialize]
        public void Initialize()
        {
            this._commentRepository = new Mock<ICommentRepository>(MockBehavior.Strict);
            this._commentService = new CommentService(this._commentRepository.Object);

            this.expectedComment = new Comment()
            {
                Id = 1,
                User = Guid.NewGuid().ToString(),
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
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

        //[TestMethod()]
        //public void GetCommentsByTopicIdTest_ValidTopicId_ShouldReturnList()
        //{
        //    // Arrange
        //    this._commentRepository.Setup(r => r.GetCommentsByTopicId(It.IsAny<int>()))
        //        .Returns(new List<Comment>() { expectedComment, expectedComment});

        //    // Act
        //    var actualComments = _commentService.GetCommentById(id);

        //    // Assert
        //    Assert.IsInstanceOfType(actualComment, typeof(Comment));
        //    Assert.AreEqual(expectedComment, actualComment);
        //    this._commentRepository.VerifyAll();
        //}

        //[TestMethod()]
        //public void CreateCommentTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void UpdateCommentTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DeleteCommentTest()
        //{
        //    Assert.Fail();
        //}
    }
}
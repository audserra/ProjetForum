using forum_api.DataAccess.DataObjects;
using forum_api.Exceptions;
using forum_api.Repositories;

namespace forum_api.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly ITopicService _topicService;

        public CommentService(ICommentRepository repository, ITopicService topicService)
        {
            this._repository = repository;
            this._topicService = topicService;
        }

        public Comment GetCommentById(int id)
        {
            var comment = _repository.GetCommentById(id);
            if(comment == null)
            {
                throw new NotFoundException("Ce CommentID n'existe pas.");
            }
            return comment;

        }
        public List<Comment> GetCommentsByTopicId(int topicId)
        {
            _ = this._topicService.GetTopicById(topicId);
            var comments = _repository.GetCommentsByTopicId(topicId);
            return comments;
        }
        public Comment CreateComment(Comment comment)
        {
            _ = this._topicService.GetTopicById(comment.TopicId);
            comment.CreationDate = DateTime.Now;
            return this._repository.CreateComment(comment);
        }
        public Comment UpdateComment(Comment comment)
        {
            _ = this._topicService.GetTopicById(comment.TopicId);
            comment.ModificationDate = DateTime.Now;
            return this._repository.UpdateComment(comment);
        }

        public void DeleteComment(int id)
        {
            _ = this.GetCommentById(id);        
            this._repository.DeleteComment(id);
        }
    }
}

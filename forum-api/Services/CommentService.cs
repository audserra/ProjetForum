using forum_api.DataAccess.DataObjects;
using forum_api.Repositories;

namespace forum_api.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            this._repository = repository;
        }

        public Comment GetCommentById(int id)
        {
            return this._repository.GetCommentById(id);
        }
        public List<Comment> GetCommentsByTopicId(int topicId)
        {
            return this._repository.GetCommentsByTopicId(topicId);
        }
        public void CreateComment(Comment comment)
        {
            this._repository.CreateComment(comment);
        }
        public void UpdateComment(int id, Comment comment)
        {
            this._repository.UpdateComment(id, comment);
        }

        public void DeleteComment(int id)
        {
            this._repository.DeleteComment(id);
        }
    }
}

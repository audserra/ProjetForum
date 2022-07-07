using forum_api.DataAccess.DataObjects;
using forum_api.Exceptions;
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
            var comment = _repository.GetCommentById(id);
            if(comment == null)
            {
                throw new NotFoundException("Ce CommentID n'existe pas.");
            }
            return comment;

        }
        public List<Comment> GetCommentsByTopicId(int topicId)
        {
            var comments = _repository.GetCommentsByTopicId(topicId);
            //TODO : Verifier si le Topic existe
            //if(comments == null)
            //{
            //    throw new NotFoundException("Ce TopicID n'existe pas.");
            //}
            return comments;
        }
        public Comment CreateComment(Comment comment)
        {
            //TODO : Verifier si le Topic existe
            comment.CreationDate = DateTime.Now;
            return this._repository.CreateComment(comment);
        }
        public Comment UpdateComment(Comment comment)
        {
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

using forum_api.DataAccess.DataObjects;
using forum_api.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace forum_api.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly mangafilrouge_forumdbContext _dbContext;

        public CommentRepository(mangafilrouge_forumdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Comment GetCommentById(int id)
        {
            var comment = this._dbContext.Comments.SingleOrDefault(c => c.Id == id);
            return comment;
        }

        public List<Comment> GetCommentsByTopicId(int topicId)
        {
            List<Comment> comments = this._dbContext.Comments.Where(c => c.TopicId == topicId).ToList();
            return comments;
        }

        public Comment CreateComment(Comment comment)
        {
            this._dbContext.Comments.Add(comment);
            this._dbContext.SaveChanges();
            return comment;
        }

        public Comment UpdateComment(Comment comment)
        {
            this._dbContext.Comments.Update(comment);
            this._dbContext.SaveChanges();
            return comment;
        }

        public void DeleteComment(int id)
        {
            var comment = _dbContext.Comments.SingleOrDefault(c => c.Id == id);
            this._dbContext.Comments.Remove(comment);
            this._dbContext.SaveChanges();
        }
    }
}

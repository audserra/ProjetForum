using forum_api.DataAccess.DataObjects;

namespace forum_api.Repositories
{
    public interface ICommentRepository
    {
        void CreateComment(Comment comment);
        void DeleteComment(int id);
        Comment GetCommentById(int id);
        List<Comment> GetCommentsByTopicId(int topicId);
        void UpdateComment(int id, Comment comment);
    }
}
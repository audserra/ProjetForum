using forum_api.DataAccess.DataObjects;

namespace forum_api.Repositories
{
    public interface ICommentRepository
    {
        Comment GetCommentById(int id);
        List<Comment> GetCommentsByTopicId(int topicId);
        Comment UpdateComment(Comment comment);
        Comment CreateComment(Comment comment);
        void DeleteComment(int id);
    }
}
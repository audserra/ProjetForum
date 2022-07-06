using forum_api.DataAccess.DataObjects;

namespace forum_api.Services
{
    public interface ICommentService
    {
        Comment GetCommentById(int id);
        List<Comment> GetCommentsByTopicId(int topicId);
        Comment CreateComment(Comment comment);
        Comment UpdateComment(Comment comment);
        void DeleteComment(int id);
    }
}
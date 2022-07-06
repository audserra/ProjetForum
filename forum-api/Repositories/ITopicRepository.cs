using forum_api.DataAccess.DataObjects;

namespace forum_api.Repositories
{
    public interface ITopicRepository
    {
        Topic AddTopic(Topic topic);
        Topic DeleteTopic(int id);
        Topic GetTopicById(int id);
        IEnumerable<Topic> GetTopics();
        Topic UpdateTopic(Topic topic);
    }
}
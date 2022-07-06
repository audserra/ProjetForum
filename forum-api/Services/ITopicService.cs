using forum_api.DataAccess.DataObjects;

namespace forum_api.Services
{
    public interface ITopicService
    {
        Topic AddTopic(Topic topic);
        void DeleteTopic(int id);
        Topic GetTopicById(int id);
        IEnumerable<Topic> GetTopics();
        Topic UpdateTopic(Topic topic);
    }
}
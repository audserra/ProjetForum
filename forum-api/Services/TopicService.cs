using forum_api.DataAccess.DataObjects;
using forum_api.Repositories;

namespace forum_api.Services
{
    public class TopicService : ITopicService
    {
        private ITopicRepository topicRepository;
        public TopicService(ITopicRepository repo)
        {
            topicRepository = repo;
        }

        public Topic AddTopic(Topic topic)
        {
            topic.CreationDate = DateTime.Now;
            return this.topicRepository.AddTopic(topic);
        }

        public void DeleteTopic(int id)
        {
            Topic topic = this.topicRepository.DeleteTopic(id);
            if(topic == null)
            {
                throw new Exception("Error : Tried to delete a topic which doesn't exist !");
            }
        }

        public Topic GetTopicById(int id)
        {
            return this.topicRepository.GetTopicById(id);
        }

        public IEnumerable<Topic> GetTopics()
        {
            return this.topicRepository.GetTopics();
        }

        public Topic UpdateTopic(Topic topic)
        {
            topic.ModificationDate = DateTime.Now;
            return this.topicRepository.UpdateTopic(topic);
        }
    }
}

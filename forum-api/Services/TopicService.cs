using forum_api.DataAccess.DataObjects;
using forum_api.Exceptions;
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
            _= this.GetTopicById(id);
            this.topicRepository.DeleteTopic(id);
        }

        public Topic GetTopicById(int id)
        {
            Topic topic = this.topicRepository.GetTopicById(id);

            if(topic == null)
            {
                throw new NotFoundException("Ce topic n'existe pas"); 
            }

            return topic;
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

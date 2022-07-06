using forum_api.DataAccess.DataObjects;

namespace forum_api.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly mangafilrouge_forumdbContext context;
        public TopicRepository(mangafilrouge_forumdbContext Context)
        {
            context = Context;
        }

        public Topic AddTopic(Topic topic)
        {
            this.context.Topics.Add(topic);
            this.context.SaveChanges();
            return topic;
        }

        public Topic DeleteTopic(int id)
        {
            Topic topic = this.context.Topics.FirstOrDefault(a => a.Id == id);
            if (topic != null)
            {
                this.context.Topics.Remove(topic);
                this.context.SaveChanges();
            }
            return topic;
        }

        public Topic GetTopicById(int id)
        {
            Topic topic = this.context.Topics.FirstOrDefault(a => a.Id == id);

            if (topic != null)
            {
                topic.Comments = this.context.Comments.Where(com => com.TopicId == topic.Id).ToList();
            }

            return topic;
        }

        public IEnumerable<Topic> GetTopics()
        {
            List<Topic> topics = this.context.Topics.ToList();

            if (topics != null)
            {
                foreach (var topic in topics)
                {
                    topic.Comments = this.context.Comments.Where(com => com.TopicId == topic.Id).ToList();
                }
            }

            return topics;
        }

        public Topic UpdateTopic(Topic topic)
        {
            this.context.Topics.Update(topic);
            this.context.SaveChanges();
            return topic;
        }
    }
}

using forum_api.DataAccess.DataObjects;
using forum_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace forum_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService topicService;

        public TopicController(ITopicService service)
        {
            topicService = service;
        }

        [HttpGet("{id}")]
        public Topic GetTopicById(int id)
        {
            return this.topicService.GetTopicById(id);
        }

        [HttpGet]
        public IEnumerable<Topic> GetTopics()
        {
            return this.topicService.GetTopics();
        }

        [HttpPost]
        public Topic AddTopic(Topic topic)
        {
            return this.topicService.AddTopic(topic);
        }

        [HttpPut]
        public Topic UpdateTopic(Topic topic)
        {
            return this.topicService.UpdateTopic(topic);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTopic(int id)
        {
            try 
            {
                this.topicService.DeleteTopic(id);
                return Ok();
            }
            catch (Exception e)
            {
                return  BadRequest("Invalide request" + e.Message);
            }
        }
    }
}

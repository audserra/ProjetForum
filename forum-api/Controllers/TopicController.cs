using forum_api.DataAccess.DataObjects;
using forum_api.Exceptions;
using forum_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace forum_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService topicService;

        public TopicController(ITopicService service)
        {
            topicService = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetTopicById(int id)
        {
            try
            {
                return Ok(this.topicService.GetTopicById(id));
            }

            catch (NotFoundException e)
            {
                return BadRequest("Invalide get request :" + e.Message);

            }
        }

        [HttpGet]
        public IEnumerable<Topic> GetTopics()
        {
            return this.topicService.GetTopics();
        }

        [HttpPost]
        public IActionResult AddTopic(Topic topic)
        {
            Topic topicCreated = this.topicService.AddTopic(topic);
            return CreatedAtAction(nameof(GetTopicById), new { id = topicCreated.Id }, topicCreated);
        }

        [HttpPut]
        public IActionResult UpdateTopic(Topic topic)
        {
            try
            {
                return Ok(this.topicService.UpdateTopic(topic));
            }
            catch (NotFoundException ex)
            {
                return BadRequest($"Erreur d'update : {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTopic(int id)
        {
            try
            {
                this.topicService.DeleteTopic(id);
                return Ok("Deleted!");
            }
            catch (NotFoundException ex)
            {
                return BadRequest($"Erreur de suppression : {ex.Message}");
            }
        }
    }
}

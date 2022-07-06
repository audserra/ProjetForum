using forum_api.DataAccess.DataObjects;
using forum_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace forum_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentsController(ICommentService service)
        {
            this._service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            return Ok(this._service.GetCommentById(id));
        }

        [HttpGet("topic/{topicId}")]
        public IActionResult GetCommentsByyTopicId(int topicId)
        {
            return Ok(this._service.GetCommentsByTopicId(topicId));
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            this._service.CreateComment(comment);
            return Ok("Created!");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, Comment comment)
        {
            this._service.UpdateComment(id, comment);
            return Ok("Updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            this._service.DeleteComment(id);
            return Ok("Deleted!");
        }
    }
}

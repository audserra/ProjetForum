using forum_api.DataAccess.DataObjects;
using forum_api.Exceptions;
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
            try
            {
                return Ok(this._service.GetCommentById(id));
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("topic/{topicId}")]
        public IActionResult GetCommentsByyTopicId(int topicId)
        {
            try
            {
                return Ok(this._service.GetCommentsByTopicId(topicId));
            }
            catch(NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            return Ok(this._service.CreateComment(comment));
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            try
            {
                return Ok(this._service.UpdateComment(comment));
            }
            catch(NotFoundException ex)
            {
                return BadRequest($"Erreur d'update : {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            try
            {
                this._service.DeleteComment(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return BadRequest($"Erreur de suppression : {ex.Message}");
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjekatNaVezbama.DTO;
using ProjekatNaVezbama.Services;

namespace ProjekatNaVezbama.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        
        [HttpPost("new_comments")]
        public async Task<ActionResult<CommentOutDTO>> CreateComment(CommentCreateDTO commentDTO)
        {
            var retVal = await _commentService.CreateComment(commentDTO);
            if (retVal != null)
            {
                if (retVal.CreatorUsername.IsNullOrEmpty() || retVal.CreatorUsername.Equals("-1"))
                {
                    return NotFound("No such user.");
                }
                //  don't remember why 
                if(retVal.PostID == null || retVal.PostID == -1)
                {
                    return NotFound("Post doesn't exist");
                }

                return CreatedAtAction(nameof(CreateComment), new { id = retVal.ID }, retVal);
            }

            return BadRequest();
        }
        
        // GET: api/<UsersController>s
        [HttpGet("get_comments")]
        //am I allowed to rename Get into GetAllPosts or something?
        public async Task<ActionResult<IEnumerable<CommentOutDTO>>> GetAllComments()
        {
            var retVal = await _commentService.GetAllComments();
            return retVal != null ? Ok(retVal) : NoContent();
        }

        // GET: api/<UsersController>
        [HttpGet("get_one_comment")]
        public async Task<ActionResult<CommentOutDTO>> GetOnePost(int id)
        {
            var retVal = await _commentService.GetComment(id);
            //fix this depending on if the user exists or if the post is deleted,
            //but add user deleted and post deleted first
            return retVal is null ? NotFound() : Ok(retVal);
        }


        [HttpGet("get_post_comment")]
        public async Task<ActionResult<List<PostOutDTO>>> GetOnePostComment([FromQuery] int postID)
        {
            var retVal = await _commentService.GetPostComments(postID);

            //work on this
            return retVal is null ? NotFound() : /*(retVal.ID == -1 ? NotFound("Post deleted.") :*/ Ok(retVal);
        }

        //Delete
        [HttpDelete("deactivate_comment")]
        public async Task<ActionResult> DeleteComment(int commentID)
        {
            var retVal = await _commentService.DeleteComment(commentID);

            return retVal == false ? NotFound() : Ok();
        }
    }
}

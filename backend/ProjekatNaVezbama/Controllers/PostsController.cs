using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjekatNaVezbama.DB;
using ProjekatNaVezbama.DTO;
using ProjekatNaVezbama.Model;
using ProjekatNaVezbama.Services;

namespace ProjekatNaVezbama.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService context)
        {
            _postService = context;
        }


        [HttpPost("create_post")]
        public async Task<ActionResult<PostOutDTO>> CreatePost(PostCreateDTO postDTO)
        {
            var retVal = await _postService.CreatePost(postDTO);
            if(retVal != null)
            {
                return CreatedAtAction(nameof(CreatePost), new { id = retVal.ID }, retVal); 
            }

            return NotFound("User not found");
        }

        // GET: api/<PostsController>s
        [HttpGet("get_all_posts")]
        public async Task<ActionResult<IEnumerable<PostOutDTO>>> GetAllPosts()
        {
            var retVal = await _postService.GetAllPosts();
            return retVal != null ? Ok(retVal) : NoContent();
        }

        // GET: api/<UsersController>
        [HttpGet("get_post/id")]
        public async Task<ActionResult<PostOutDTO>> GetOnePost([FromQuery] int id)
        {
            var retVal = await _postService.GetPost(id);

            return retVal is null ? NotFound() : (retVal.ID == -1 ? NotFound("Post deleted.") : retVal);
        }

        [HttpGet("get_user_post")]
        public async Task<ActionResult<List<PostOutDTO>>> GetOneUsersPost([FromQuery] string username)
        {
            var retVal = await _postService.GetUsersPost(username);

            //work on this
            return retVal is null ? NotFound() : /*(retVal.ID == -1 ? NotFound("Post deleted.") :*/ Ok(retVal);
        }

        //Delete
        [HttpDelete("delete_post")]
        public async Task<ActionResult> DeletePost(int id)
        {
            var retVal = await _postService.DeletePost(id);

            return retVal == false ? NotFound() : NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjekatNaVezbama.DB;
using ProjekatNaVezbama.DTO;
using ProjekatNaVezbama.Model;
using ProjekatNaVezbama.Services;

namespace ProjekatNaVezbama.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService context)
        {
            _userService = context;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOutDTO>>> Get()
        {
            var retVal = await _userService.GetAllUsers();
            return Ok(retVal);
        }

        
        // GET: api/<UsersController>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOutDTO>> Get(int id)
        { 
            var retVal = await _userService.GetUser(id);

            return retVal is null ? NotFound() : Ok(retVal);
        }

        //make new user
        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserOutDTO>> Post(UserCreateDTO user)
        {
            UserOutDTO retVal = await _userService.CreateUser(user);           

            return CreatedAtAction(nameof(Post), new { id = retVal.ID }, retVal);
        }

        //Delete
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var retVal = await _userService.DeleteUser(id);

            return retVal == false ? NotFound() : NoContent();
        }

    }
}

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
        [HttpGet("get_users")]
        public async Task<ActionResult<IEnumerable<UserOutDTO>>> GetAllUsers()
        {
            var retVal = await _userService.GetAllUsers();
            return Ok(retVal);
        }


        // GET: api/<UsersController>
        [HttpGet("get_user/{id}")]
        public async Task<ActionResult<UserOutDTO>> GetOneUser(int id)
        {
            var retVal = await _userService.GetUser(id);

            return retVal is null ? NotFound() : Ok(retVal);
        }


        //make new user
        // POST api/<UsersController>
        [HttpPost("create_user")]
        public async Task<ActionResult<UserOutDTO>> CreateUser(UserCreateDTO user)
        {
            UserOutDTO retVal = await _userService.CreateUser(user);           

            return CreatedAtAction(nameof(CreateUser), new { id = retVal.ID }, retVal);
        }

        //Delete
        [HttpDelete("delete_user")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var retVal = await _userService.DeleteUser(id);

            return retVal == false ? NotFound() : NoContent();
        }

        [HttpPut("get_user")]
        public async Task<ActionResult<UserOutDTO>> UpdateUser(UserUpdateCreateDTO userDTO)
        {
            var retVal = await _userService.UpdateUser(userDTO);

            if(retVal != null)
            {
                var retValMessage = "";
                retValMessage += retVal.Username.CompareTo("-1") == 0 ? "invalid username " : "";
                retValMessage += retVal.Username.CompareTo("-2") == 0 ? "username taken " : "";
                retValMessage += retVal.Password.CompareTo("-1") == 0 ? "invalid password " : "";
                retValMessage += retVal.Email.CompareTo("-1") == 0 ? "invalid email" : "";

                if (!retValMessage.IsNullOrEmpty())
                {
                    return BadRequest(retValMessage);
                }

                return Ok(retVal);

            }
            return BadRequest("no such user");
        }

        

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.DTO;
using PSW_ClinicSystem.IServices;
using AutoMapper;

namespace PSW_ClinicSystem.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private IMapper mapper; // mapping Db entities to DTOs

        public UserController(IUserService userS, IMapper maper)
        {
            mapper = maper;
            userService = userS;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            var user = await userService.Authenticate(model.name, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = userService.GetUsers();  // List UserResponseDTO
                //var usersResult = mapper.Map<IEnumerable<UserDTO>>(users);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error, kontroler");
            }

        }
    }
}


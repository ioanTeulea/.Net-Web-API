using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Servicies;

namespace Project.Api.Controllers
{
    public class UserController : BaseController
    {
        private UsersService usersService { get; set; }


        public UserController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost("/register")]
        [AllowAnonymous]
        public IActionResult Register(Database.Dtos.Request.RegisterRequest payload)
        {
            usersService.Register(payload);
            return Ok("Registration successful");
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login(Database.Dtos.Request.LoginRequest payload)
        {
            var jwtToken = usersService.Login(payload);

            return Ok(new { token = jwtToken });
        }
    }
}

using Application;
using Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeBookBackend.Filters;

namespace RecipeBookBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ValidateModel]
        public IActionResult Registration([FromBody] RegistrationFormDto registrationForm)
        {
            try
            {
                return Ok(_userService.Registration(registrationForm));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("login")]
        [ValidateModel]
        public IActionResult Login([FromBody] LoginFormDto loginForm)
        {

            try
            {
                return Ok(_userService.Login(loginForm));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{userId}")]
        [Authorize]
        public IActionResult GetUser(string userId)
        {
            try
            {
                return Ok(_userService.GetUserById(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

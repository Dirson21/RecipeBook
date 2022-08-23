using Application;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace RecipeBookBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]

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

        public IActionResult Login([FromForm] string login, [FromForm] string password)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

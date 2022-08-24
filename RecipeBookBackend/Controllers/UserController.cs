using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace RecipeBookBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration([FromBody] UserDto userDto)
        {
            try
            {
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPost]
        [Route("login")]
        [ValidateAntiForgeryToken]
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

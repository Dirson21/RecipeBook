using Application;
using Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeBookBackend.Filters;
using System.Security.Claims;

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

        [HttpGet]
        [Authorize]
        [Route("{userId}/recipe")]
        public IActionResult GetUserRecipes(string userId)
        {
            try
            {
                return Ok(_userService.GetUserRecipes(Guid.Parse(userId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{userId}/favorite")]
        [Authorize]
        public IActionResult GetUserFavoriteRecipe(string userId)
        {
            try
            {
                return Ok(_userService.GetUserFavoriteRecipes(Guid.Parse(userId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{userId}/favorite/count")]
        [Authorize]
        public IActionResult GetUserFavoriteRecipeCount(string userId)
        {
            try
            {
                return Ok(_userService.GetUserFavoriteRecipesCount(Guid.Parse(userId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("{userId}/like/count")]
        [Authorize]
        public IActionResult GetUserLikesCount(string userId)
        {
            try
            {
                return Ok(_userService.GetUserLikesCount(Guid.Parse(userId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("{userId}")]
        [Authorize]
        public IActionResult UpdateUser([FromBody] UserAccountDto userAccountDto)
        {
            try
            {
                Claim nameIdentifier = Request.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(nameIdentifier.Value);
                if (userAccountDto.Id != userId)
                {
                    throw new Exception("Неверный пользователь");
                }

                return Ok(_userService.UpdateUser(userAccountDto));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}

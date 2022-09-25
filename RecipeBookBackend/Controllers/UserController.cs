using Application;
using Application.Dto;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(_userService.Registration(registrationForm));
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginFormDto loginForm)
        {
            return Ok(_userService.Login(loginForm));
        }

        [HttpGet]
        [Route("{userId}")]
        [Authorize]
        public IActionResult GetUser(string userId)
        {
            return Ok(_userService.GetUserById(userId));
        }

        [HttpGet]
        [Authorize]
        [Route("{userId}/recipe")]
        public IActionResult GetUserRecipes(string userId)
        {
            return Ok(_userService.GetUserRecipes(Guid.Parse(userId)));
        }

        [HttpGet]
        [Route("{userId}/favorite")]
        [Authorize]
        public IActionResult GetUserFavoriteRecipe(string userId)
        {
            return Ok(_userService.GetUserFavoriteRecipes(Guid.Parse(userId)));
        }

        [HttpGet]
        [Route("{userId}/favorite/count")]
        [Authorize]
        public IActionResult GetUserFavoriteRecipeCount(string userId)
        {
            return Ok(_userService.GetUserFavoriteRecipesCount(Guid.Parse(userId)));
        }


        [HttpGet]
        [Route("{userId}/like/count")]
        [Authorize]
        public IActionResult GetUserLikesCount(string userId)
        {
            return Ok(_userService.GetUserLikesCount(Guid.Parse(userId)));

        }
        [HttpPut]
        [Route("{userId}")]
        [Authorize]
        public IActionResult UpdateUser([FromBody] UserAccountDto userAccountDto)
        {
            Claim nameIdentifier = Request.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            Guid userId = Guid.Parse(nameIdentifier.Value);
            if (userAccountDto.Id != userId)
            {
                throw new OwnerException("InvalidUser");
            }

            return Ok(_userService.UpdateUser(userAccountDto));
        }
    }
}

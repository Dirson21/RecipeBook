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
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IImageService _imageService;


        public RecipeController(IRecipeService recipeService, IImageService imageService)
        {
            _recipeService = recipeService;
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult GetRecipes()
        {

            Guid userId = GetUserId();

            return Ok(_recipeService.GetRecipes(userId));
        }

        [HttpGet]
        [Route("{recipeId}")]
        public IActionResult GetRecipe(int recipeId)
        {

            Guid userId = GetUserId();
            return Ok(_recipeService.GetRecipeById(recipeId, userId));

        }

        [HttpGet]
        [Route("range")]
        public IActionResult GetRecipeRange([FromQuery] int start, [FromQuery] int count)
        {

            Guid userId = GetUserId();
            return Ok(_recipeService.GetRecipes(start, count, userId));

        }

        [HttpGet]
        [Route("search")]
        public IActionResult SearchRecipes([FromQuery] string search, [FromQuery] int start, [FromQuery] int count)
        {

            Guid userId = GetUserId();
            return Ok(_recipeService.SearchRecipe(search, userId, start, count));


        }

        [HttpGet]
        [Route("recipeDay")]
        public IActionResult GetRecipeDay()
        {

            Guid userId = GetUserId();
            return Ok(_recipeService.GetRecipeDay(userId));


        }

        [HttpPost]
        [Authorize]
        public IActionResult AddRecipe([FromBody] RecipeDto recipeDto)
        {

            Guid userId = GetUserId();
            return Ok(_recipeService.CreateRecipe(recipeDto, userId));

        }

        [HttpDelete]
        [Route("{recipeId}")]
        [Authorize]
        public IActionResult DeleteRecipe(int recipeId)
        {

            Guid userId = GetUserId();
            RecipeDto recipeDto = _recipeService.GetRecipeById(recipeId, userId);

            if (recipeDto.UserAccount.Id != userId)
            {
                throw new OwnerException("InvalidUser");
            }

            _recipeService.DeleteRecipe(recipeId);
            return Ok();


        }

        [HttpPut]
        [Authorize]
        [Route("image")]

        public IActionResult AddRecipeImage([FromForm] int recipeId, [FromForm] IFormFile image)
        {

            Guid userId = GetUserId();
            RecipeDto recipeDto = _recipeService.GetRecipeById(recipeId, userId);

            if (recipeDto.UserAccount.Id != userId)
            {
                throw new OwnerException("InvalidUser");
            }

            _imageService.addRecipeImage(recipeId, image);

            return Ok();


        }

        [HttpPut]
        [Authorize]
        [Route("{recipeId}")]
        public IActionResult UpdateRecipe([FromBody] RecipeDto recipeDto)
        {

            Guid userId = GetUserId();
            if (recipeDto.UserAccount.Id != userId)
            {
                throw new OwnerException("InvalidUser");
            }

            return Ok(_recipeService.UpdateRecipe(recipeDto));

        }

        [HttpPost]
        [Authorize]
        [Route("like/{recipeId}")]

        public IActionResult LikeRecipe(int recipeId)
        {

            Guid userId = GetUserId();
            _recipeService.LikeRecipe(recipeId, userId);
            return Ok();


        }

        [HttpDelete]
        [Authorize]
        [Route("like/{recipeId}")]

        public IActionResult RemoveLikeRecipe(int recipeId)
        {

            Guid userId = GetUserId();
            _recipeService.RemoveLikeRecipe(recipeId, userId);
            return Ok();

        }

        [HttpPost]
        [Authorize]
        [Route("favorite/{recipeId}")]

        public IActionResult FavoriteRecipe(int recipeId)
        {

            Guid userId = GetUserId();
            _recipeService.FavoriteRecipe(recipeId, userId);
            return Ok();


        }

        [HttpDelete]
        [Authorize]
        [Route("favorite/{recipeId}")]
        public IActionResult RemoveFavoriteRecipe(int recipeId)
        {

            Guid userId = GetUserId();
            _recipeService.RemoveFavoriteRecipe(recipeId, userId);
            return Ok();

        }

        private Guid GetUserId()
        {
            Claim nameIdentifier = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            Guid userId = Guid.Empty;
            if (nameIdentifier != null)
            {
                userId = Guid.Parse(nameIdentifier.Value);
            }
            return userId;
        }

    }



}

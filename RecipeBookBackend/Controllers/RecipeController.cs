using Application.Dto;

using Microsoft.AspNetCore.Mvc;
using Application;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using RecipeBookBackend.Filters;

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
            try
            {
                Claim nameIdentifier = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Empty;
                if (nameIdentifier != null)
                {
                     userId = Guid.Parse(nameIdentifier.Value);
                }
                
                return Ok(_recipeService.GetRecipes(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{recipeId}")]
        public IActionResult GetRecipe(int recipeId)
        {
            try
            {
                Claim nameIdentifier = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Empty;
                if (nameIdentifier != null)
                {
                    userId = Guid.Parse(nameIdentifier.Value);
                }
                return Ok(_recipeService.GetRecipeById(recipeId, userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("range")]
        public IActionResult GetRecipeRange([FromQuery] int start, [FromQuery] int count)
        {
            try
            {
                Claim nameIdentifier = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Empty;
                if (nameIdentifier != null)
                {
                    userId = Guid.Parse(nameIdentifier.Value);
                }
                return Ok(_recipeService.GetRecipes(start, count, userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddRecipe([FromBody] RecipeDto recipeDto)
        {
            try
            {
                Claim nameIdentifier = Request.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(nameIdentifier.Value);

                return Ok(_recipeService.CreateRecipe(recipeDto, userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{recipeId}")]
        [Authorize]
        public IActionResult DeleteRecipe(int recipeId)
        {
            try
            {
                Claim nameIdentifier = Request.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(nameIdentifier.Value);
                RecipeDto recipeDto = _recipeService.GetRecipeById(recipeId, userId);

                if (recipeDto.UserAccount.Id != userId)
                {
                    throw new Exception("Неверный пользователь");
                }

                _recipeService.DeleteRecipe(recipeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("image")]

        public IActionResult AddRecipeImage([FromForm] int recipeId, [FromForm] IFormFile image)
        {
            try
            {
                Claim nameIdentifier = Request.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(nameIdentifier.Value);
                RecipeDto recipeDto = _recipeService.GetRecipeById(recipeId, userId);

                if (recipeDto.UserAccount.Id != userId)
                {
                    throw new Exception("Неверный пользователь");
                }

                _imageService.addRecipeImage(recipeId, image);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [ValidateOwnerRecipe]
        [Route("{recipeId}")]
        public IActionResult UpdateRecipe([FromBody] RecipeDto recipeDto)
        {
            try
            {
                Claim nameIdentifier = Request.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(nameIdentifier.Value);
                if ( recipeDto.UserAccount.Id != userId)
                {
                    throw new Exception("Неверный пользователь");
                }

                return Ok(_recipeService.UpdateRecipe(recipeDto));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("like/{recipeId}")]

        public IActionResult LikeRecipe(int recipeId)
        {
            try
            {
                Claim nameIdentifier = Request.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(nameIdentifier.Value);
                _recipeService.LikeRecipe(recipeId, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("like/{recipeId}")]

        public IActionResult RemoveLikeRecipe(int recipeId)
        {
            try
            {
                Claim nameIdentifier = Request.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(nameIdentifier.Value);
                _recipeService.RemoveLikeRecipe(recipeId, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("favorite/{recipeId}")]

        public IActionResult FavoriteRecipe(int recipeId)
        {
            try
            {
                Claim nameIdentifier = Request.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(nameIdentifier.Value);
                _recipeService.FavoriteRecipe(recipeId, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("favorite/{recipeId}")]
        public IActionResult RemoveFavoriteRecipe(int recipeId)
        {
            try
            {
                Claim nameIdentifier = Request.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(nameIdentifier.Value);
                _recipeService.RemoveFavoriteRecipe(recipeId, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Services;

namespace RecipeBookBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController: ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public IActionResult GetRecipes ()
        {
            try
            {
                return Ok(_recipeService.GetRecipes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}

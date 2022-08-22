﻿using Application.Dto;

using Microsoft.AspNetCore.Mvc;
using Application;

namespace RecipeBookBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController: ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IImageService _imageService;

        public RecipeController(IRecipeService recipeService, IImageService imageService)
        {
            _recipeService = recipeService;
            _imageService = imageService;
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

        [HttpGet]
        [Route("{recipeId}")]
        public IActionResult GetRecipe(int recipeId)
        {
            try
            {
                return Ok(_recipeService.GetRecipeById(recipeId));
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
                return Ok(_recipeService.GetRecipes(start, count));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddRecipe ([FromBody] RecipeDto recipeDto)
        {
            try
            {
                return Ok(_recipeService.CreateRecipe(recipeDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{recipeId}")]
        public IActionResult DeleteRecipe(int recipeId)
        {
            try
            {
                _recipeService.DeleteRecipe(recipeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("image")]

        public IActionResult addRecipeImage([FromForm] int recipeId, [FromForm] IFormFile image)
        {
            
            try
            {
                _imageService.addRecipeImage(recipeId, image);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}

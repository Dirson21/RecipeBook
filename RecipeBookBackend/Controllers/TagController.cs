﻿using Dto;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace RecipeBookBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TagController: ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

       [HttpGet]
       public IActionResult GetTags()
       {
            try
            {
                return Ok(_tagService.getTags());
            }
            catch (Exception ex)
            {
                return  BadRequest(ex.Message);
            }
       }

        

        [HttpPut]
        public IActionResult AddRecipeToTag([FromForm]int tagId, [FromForm] int recipeId)
        {
           
            try
            {
                _tagService.AddRecipeToTag(tagId, recipeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult AddTag([FromBody] TagDto tag)
        {
            try
            {
                return Ok(_tagService.CreateTag(tag));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route ("{tagId}")]
        public IActionResult DeleteTag(int tagId)
        {
            try
            {
                _tagService.DeleteTag(tagId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
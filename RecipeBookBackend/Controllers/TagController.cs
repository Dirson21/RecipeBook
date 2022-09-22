using Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Application;

namespace RecipeBookBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public IActionResult GetTags()
        {
            return Ok(_tagService.GetTags());
        }
    }
}

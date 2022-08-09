using Domain;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converters
{
    public static class TagExtention
    {
        public static TagDto ConvertToTagDto (this Tag tag)
        {
            return new TagDto
            {
                Id = tag.Id,
                Name = tag.Name,
                Image = tag.Image,
                Description = tag.Description,
                Recipes = tag.Recipes?.ConvertAll(recipe => recipe.ConvertToRecipeDto())
            };
        }

        public static Tag ConvertToTag(this TagDto tagDto)
        {
            return new Tag
            {
                Id = tagDto.Id,
                Name = tagDto.Name,
                Image = tagDto.Image,
                Description= tagDto.Description,
                Recipes = tagDto.Recipes?.ConvertAll(recipe => recipe.ConvertToRecipe())
            };
        }
    }
}

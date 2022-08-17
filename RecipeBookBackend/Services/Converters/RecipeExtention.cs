using Domain;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converters
{
    public static class RecipeExtention
    {
        public static RecipeDto ConvertToRecipeDto(this Recipe recipe)
        {
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                CookingTime = recipe.CookingTime,
                CountPerson = recipe.CountPerson,
                Image = recipe.Image,
                CookingSteps = recipe.CookingSteps?.ConvertAll(c => c.ConvertToCookingStepDto()),
                Ingridients = recipe.Ingredients?.ConvertAll(c => c.ConvertToIngridientDto()),
                Tags = recipe.Tags?.ConvertAll(c => c.ConvertToTagDto())
                
            };
        }
    }
}

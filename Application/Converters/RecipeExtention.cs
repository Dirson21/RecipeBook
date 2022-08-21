using Domain;
using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters
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
                IngredientHeaders = recipe.IngredientHeaders?.ConvertAll(c => c.ConvertToIngridientHeaderDto()),
                Tags = recipe.Tags?.ConvertAll(c => c.ConvertToTagDto())
                
            };
        }
    }
}

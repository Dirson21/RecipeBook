using Domain;
using Dto;

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
            //Убираем свзяь, чтобы избежать циклов
            foreach( var tag in  recipe.Tags)
            {
                tag.Recipes = new List<Recipe>();
            }


            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                CookingTime = recipe.CookingTime,
                CountPerson = recipe.CountPerson,
                Image = recipe.Image,
                CookingSteps = recipe.CookingSteps?.ConvertAll(c => c.ConvertToCookingStepDto()),
                Ingridients = recipe.Ingridients?.ConvertAll(c => c.ConvertToIngridientDto()),
                Tags = recipe.Tags?.ConvertAll(c => c.ConvertToTagDto())
                
            };
        }
        public static Recipe ConvertToRecipe(this RecipeDto recipeDto)
        {
            return new Recipe
            {
                Id = recipeDto.Id,
                Name = recipeDto.Name,
                Description = recipeDto.Description,
                CookingTime = recipeDto.CookingTime,
                CountPerson = recipeDto.CountPerson,
                Image = recipeDto.Image,
                CookingSteps = recipeDto?.CookingSteps.ConvertAll(c => c.ConvertToCookingStep()),
                Ingridients = recipeDto?.Ingridients.ConvertAll(c => c.ConvertToIngridient()),
                Tags = recipeDto?.Tags.ConvertAll(c => c.ConvertToTag())
              
            };

        }
    }
}

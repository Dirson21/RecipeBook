using Domain;
using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters
{
    public interface IRecipeConverter
    {
        public Recipe ConvertToRecipe(RecipeDto recipeDto);

        public Recipe ConvertToRecipe(RecipeDto recipeDto, Recipe recipeData);
        public RecipeDto ConvertToRecipeDto( Recipe recipe, Guid recipeOwnerId = new Guid());
    }
}

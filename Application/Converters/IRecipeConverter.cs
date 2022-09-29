using Application.Dto;
using Domain;

namespace Application.Converters
{
    public interface IRecipeConverter
    {

        public Recipe ConvertToRecipe(RecipeDto recipeDto, Recipe recipeData);
        public RecipeDto ConvertToRecipeDto(Recipe recipe, Guid recipeOwnerId);
    }
}

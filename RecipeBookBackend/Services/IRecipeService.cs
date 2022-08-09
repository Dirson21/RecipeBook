using Dto;

namespace Services
{
    public interface IRecipeService
    {
        List<RecipeDto> GetRecipes();
    }
}

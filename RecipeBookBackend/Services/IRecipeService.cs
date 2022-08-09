using RecipeBookBackend.Domain;
using RecipeBookBackend.Dto;

namespace RecipeBookBackend.Services
{
    public interface IRecipeService
    {
        List<RecipeDto> GetRecipes();
    }
}

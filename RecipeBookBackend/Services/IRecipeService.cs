using Dto;

namespace Services
{
    public interface IRecipeService
    {
        List<RecipeDto> GetRecipes();
        List<RecipeDto> GetRecipes(int start, int count);
        RecipeDto GetRecipeById(int id);
        RecipeDto GetRecipeByName(string name);

        int CreateRecipe(RecipeDto recipe);
        int UpdateRecipe(RecipeDto recipe);
        void DeleteRecipe(RecipeDto recipe);


    }
}

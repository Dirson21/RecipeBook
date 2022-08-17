using Application.Dto;

namespace Application
{
    public interface IRecipeService
    {
        List<RecipeDto> GetRecipes();
        List<RecipeDto> GetRecipes(int start, int count);
        RecipeDto GetRecipeById(int id);
        RecipeDto GetRecipeByName(string name);

        int CreateRecipe(RecipeDto recipe);
        int UpdateRecipe(int recipeId);
        void DeleteRecipe(int recipeId);


    }
}

using Application.Dto;

namespace Application
{
    public interface IRecipeService
    {
        List<RecipeDto> GetRecipes(Guid userAccountId);
        List<RecipeDto> GetRecipes(int start, int count, Guid userAccountId);
        RecipeDto GetRecipeById(int id, Guid userAccountId);
        RecipeDto GetRecipeByName(string name, Guid userAccountId);

        int CreateRecipe(RecipeDto recipeDto, Guid recipeId);
        int UpdateRecipe(RecipeDto recipeDto);
        void DeleteRecipe(int recipeId);

        void LikeRecipe(int recipeId, Guid userAccountId);
        void RemoveLikeRecipe(int recipeId, Guid userAccountId);

        void FavoriteRecipe(int recipeId, Guid userAccountId);
        void RemoveFavoriteRecipe(int recipeId, Guid userAccountId);

        List<RecipeDto> SearchRecipe(string search,Guid userAccountId , int start, int count);

        



    }
}

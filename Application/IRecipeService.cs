using Application.Dto;

namespace Application
{
    public interface IRecipeService
    {
        List<RecipeDto> GetRecipes(Guid recipeOwnerId);
        List<RecipeDto> GetRecipes(int start, int count, Guid recipeOwnerId);
        RecipeDto GetRecipeById(int id, Guid recipeOwnerId);
        RecipeDto GetRecipeByName(string name, Guid recipeOwnerId);

        int CreateRecipe(RecipeDto recipeDto, Guid recipeId);
        int UpdateRecipe(RecipeDto recipeDto);
        void DeleteRecipe(int recipeId);

        void LikeRecipe(int recipeId, Guid userAccountId);
        void RemoveLikeRecipe(int recipeId, Guid userAccountId);

        void FavoriteRecipe(int recipeId, Guid userAccountId);

        void RemoveFavoriteRecipe(int recipeId, Guid userAccountId);

        



    }
}

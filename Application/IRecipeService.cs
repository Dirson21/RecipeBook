using Application.Dto;

namespace Application
{
    public interface IRecipeService
    {
        List<RecipeDto> GetRecipes(Guid recipeOwnerId = new Guid());
        List<RecipeDto> GetRecipes(int start, int count, Guid recipeOwnerId = new Guid());
        RecipeDto GetRecipeById(int id, Guid recipeOwnerId = new Guid());
        RecipeDto GetRecipeByName(string name, Guid recipeOwnerId = new Guid());

        int CreateRecipe(RecipeDto recipeDto, Guid recipeId);
        int UpdateRecipe(RecipeDto recipeDto);
        void DeleteRecipe(int recipeId);

        void LikeRecipe(int recipeId, Guid userAccountId);
        void RemoveLikeRecipe(int recipeId, Guid userAccountId);

        void FavoriteRecipe(int recipeId, Guid userAccountId);

        void RemoveFavoriteRecipe(int recipeId, Guid userAccountId);

        



    }
}

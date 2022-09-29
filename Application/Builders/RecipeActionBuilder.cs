using Application.Dto;
using Domain;
using Domain.Repositoy;
using Microsoft.AspNetCore.Identity;

namespace Application.Builders
{
    public class RecipeActionBuilder : IRecipeActionBuilder
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly UserManager<UserAccount> _userManager;

        public RecipeActionBuilder(IRecipeRepository recipeRepository, UserManager<UserAccount> userManager)
        {
            _recipeRepository = recipeRepository;
            _userManager = userManager;

        }

        public RecipeDto BuildActionRecipe(Recipe recipe, Guid userAccountId = new Guid())
        {

            RecipeDto recipeDto = new RecipeDto();
            recipeDto.CountLike = _recipeRepository.CountLike(recipe);
            recipeDto.CountFavorite = _recipeRepository.CountFavorite(recipe);

            if (userAccountId != Guid.Empty)
            {
                UserAccount userAccount = _userManager.FindByIdAsync(userAccountId.ToString()).GetAwaiter().GetResult();
                recipeDto.IsLike = _recipeRepository.IsLike(recipe, userAccount);
                recipeDto.IsFavorite = _recipeRepository.IsFavorite(recipe, userAccount);
                return recipeDto;
            }

            recipeDto.IsLike = false;
            recipeDto.IsFavorite = false;

            return recipeDto;
        }
    }
}

using Application.Dto;
using Domain;

namespace Application.Builders
{
    public interface IRecipeActionBuilder
    {
        public RecipeDto BuildActionRecipe(Recipe recipe, Guid userAccountId = new Guid());
    }
}

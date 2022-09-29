using Application.Builders;
using Application.Dto;
using Domain;

namespace Application.Converters
{
    public class RecipeConverter : IRecipeConverter
    {
        private readonly IUserAccountConverter _userAccountConverter;
        private readonly ITagBuilder _tagBuilder;
        private readonly IRecipeActionBuilder _recipeActionBuilder;

        public RecipeConverter(IUserAccountConverter userAccountConverter, ITagBuilder tagBuilder, IRecipeActionBuilder recipeActionBuilder)
        {
            _userAccountConverter = userAccountConverter;
            _tagBuilder = tagBuilder;
            _recipeActionBuilder = recipeActionBuilder;
        }

        public Recipe ConvertToRecipe(RecipeDto recipeDto, Recipe recipe)
        {

            recipe.Tags = _tagBuilder.BuildFromTagDto(recipeDto.Tags);
            recipe.Name = recipeDto.Name;
            recipe.Description = recipeDto.Description;
            recipe.CookingTime = recipeDto.CookingTime;
            recipe.CountPerson = recipeDto.CountPerson;
            recipe.Image = recipeDto.Image;
            recipe.CookingSteps = recipeDto.CookingSteps?.ConvertAll(c => c.ConvertToCookingStep());
            recipe.IngredientHeaders = recipeDto.IngredientHeaders?.ConvertAll(c => c.ConvertToIngridientHeader());

            return recipe;
        }

        public RecipeDto ConvertToRecipeDto(Recipe recipe, Guid recipeOwnerId = new Guid())
        {
            RecipeDto recipeDto = _recipeActionBuilder.BuildActionRecipe(recipe, recipeOwnerId);

            recipeDto.Id = recipe.Id;
            recipeDto.Name = recipe.Name;
            recipeDto.Description = recipe.Description;
            recipeDto.CookingTime = recipe.CookingTime;
            recipeDto.CountPerson = recipe.CountPerson;
            recipeDto.Image = recipe.Image;
            recipeDto.CookingSteps = recipe.CookingSteps?.ConvertAll(c => c.ConvertToCookingStepDto());
            recipeDto.IngredientHeaders = recipe.IngredientHeaders?.ConvertAll(c => c.ConvertToIngridientHeaderDto());
            recipeDto.Tags = recipe.Tags?.ConvertAll(c => c.ConvertToTagDto());
            recipeDto.UserAccount = _userAccountConverter.ConvertToUserAccountDto(recipe.UserAccount);

            return recipeDto;
        }
    }
}

using Domain;
using Domain.Repositoy;
using Infrastructure.Data.Models;
using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Builders;

namespace Application.Converters
{
    public class RecipeConverter: IRecipeConverter
    {
        private readonly ITagRepository _tagRepositry;
        private readonly IUserAccountConverter _userAccountConverter;
        private readonly ITagBuilder _tagBuilder;
        private readonly IRecipeActionBuilder _recipeActionBuilder;

        public RecipeConverter(ITagRepository tagRepository, IUserAccountConverter userAccountConverter, ITagBuilder tagBuilder, IRecipeActionBuilder recipeActionBuilder)
        {
            _tagRepositry = tagRepository;
            _userAccountConverter = userAccountConverter;
            _tagBuilder = tagBuilder;
            _recipeActionBuilder = recipeActionBuilder;
        }
        public Recipe ConvertToRecipe(RecipeDto recipeDto)
        {

            Recipe recipe = new Recipe();
            recipe.Tags = _tagBuilder.BuildFromTagDto(recipeDto.Tags);

            recipe.Id = recipeDto.Id;
            recipe.Name = recipeDto.Name;
            recipe.Description = recipeDto.Description;
            recipe.CookingTime = recipeDto.CookingTime;
            recipe.CountPerson = recipeDto.CountPerson;
            recipe.Image = recipeDto.Image;
            recipe.CookingSteps = recipeDto.CookingSteps?.ConvertAll(c => c.ConvertToCookingStep());
            recipe.IngredientHeaders = recipeDto.IngredientHeaders?.ConvertAll(c => c.ConvertToIngridientHeader());
           
            return recipe;
        }

        public Recipe ConvertToRecipe(RecipeDto recipeDto, Recipe recipeData)
        {
            Recipe recipe = ConvertToRecipe(recipeDto);

            recipeData.Name = recipe.Name;
            recipeData.Description = recipe.Description;
            recipeData.Tags = recipe.Tags;
            recipeData.CookingTime = recipe.CookingTime;
            recipeData.CountPerson = recipe.CountPerson;
            recipeData.IngredientHeaders = recipe.IngredientHeaders;
            recipeData.CookingSteps = recipe.CookingSteps;
            return recipeData;
        }

        public  RecipeDto ConvertToRecipeDto(Recipe recipe, Guid recipeOwnerId = new Guid())
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

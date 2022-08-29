using Domain;
using Domain.Repositoy;
using Infrastructure.Data.Models;
using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters
{
    public class RecipeConverter: IRecipeConverter
    {
        private readonly ITagRepository _tagRepositry;
        private readonly IUserAccountConverter _userAccountConverter;

        public RecipeConverter(ITagRepository tagRepository, IUserAccountConverter userAccountConverter)
        {
            _tagRepositry = tagRepository;
            _userAccountConverter = userAccountConverter;
        }
        public Recipe ConvertToRecipe(RecipeDto recipeDto)
        {
            Recipe recipe = new Recipe();
            if (recipeDto.Tags != null)
            {
                foreach (var tagDto in recipeDto.Tags)
                {
                    Tag tag = _tagRepositry.GetByName(tagDto.Name);
                    if (tag != null)
                    {
                        recipe.Tags.Add(tag);
                    }
                    else
                    {
                        recipe.Tags.Add(tagDto.ConvertToTag());
                    }
                }
            }

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

        public  RecipeDto ConvertToRecipeDto(Recipe recipe)
        {
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                CookingTime = recipe.CookingTime,
                CountPerson = recipe.CountPerson,
                Image = recipe.Image,
                CookingSteps = recipe.CookingSteps?.ConvertAll(c => c.ConvertToCookingStepDto()),
                IngredientHeaders = recipe.IngredientHeaders?.ConvertAll(c => c.ConvertToIngridientHeaderDto()),
                Tags = recipe.Tags?.ConvertAll(c => c.ConvertToTagDto()),
                UserAccount =  _userAccountConverter.ConvertToUserAccountDto(recipe.UserAccount)
            };
        }
    }
}

using Domain;
using Infrastructure.Data.Models;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converters
{
    public class RecipeConverter
    {
        private readonly ITagRepository _tagRepositry;

        public RecipeConverter(ITagRepository tagRepository)
        {
            _tagRepositry = tagRepository;
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
            recipe.Ingridients = recipeDto.Ingridients?.ConvertAll(c => c.ConvertToIngridient());
            return recipe;
        }
    }
}

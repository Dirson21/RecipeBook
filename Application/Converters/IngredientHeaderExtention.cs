using Application.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters
{
    public static class IngredientHeaderExtention
    {
        public static IngredientHeaderDto ConvertToIngridientHeaderDto(this IngredientHeader ingridientHeader)
        {
            return new IngredientHeaderDto
            {
                Id = ingridientHeader.Id,
                Name = ingridientHeader.Name,
                RecipeId = ingridientHeader.RecipeId,
                Ingredients = ingridientHeader.Ingredients.ConvertAll(x => x.ConvertToIngridientDto())
            };
        }
        public static IngredientHeader ConvertToIngridientHeader(this IngredientHeaderDto ingridientHeaderDto)
        {
            return new IngredientHeader
            {
                Id = ingridientHeaderDto.Id,
                Name = ingridientHeaderDto.Name,
                Ingredients = ingridientHeaderDto.Ingredients.ConvertAll(x => x.ConvertToIngridient()),
                RecipeId = ingridientHeaderDto.RecipeId
                

            };
        }
    }
}

using Domain;
using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters
{
    public static class IngredientExtention
    {
        public static IngredientDto ConvertToIngridientDto(this Ingredient ingridient)
        {
            return new IngredientDto
            {
                Id = ingridient.Id,
                Name = ingridient.Name,
                IngredientHeaderId = ingridient.IngredientHeaderId
            };
        }
        public static Ingredient ConvertToIngridient(this IngredientDto ingridientDto)
        {
            return new Ingredient
            {
                Id = ingridientDto.Id,
                Name = ingridientDto.Name,
                IngredientHeaderId = ingridientDto.IngredientHeaderId

            };
        }
    }
}

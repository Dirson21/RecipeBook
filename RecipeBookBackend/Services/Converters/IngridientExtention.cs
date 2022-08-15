using Domain;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converters
{
    public static class IngridientExtention
    {
        public static IngridientDto ConvertToIngridientDto(this Ingridient ingridient)
        {
            return new IngridientDto
            {
                Id = ingridient.Id,
                Name = ingridient.Name,
                RecipeId = ingridient.RecipeId
            };
        }
        public static Ingridient ConvertToIngridient(this IngridientDto ingridientDto)
        {
            return new Ingridient
            {
                Id = ingridientDto.Id,
                Name = ingridientDto.Name,
                RecipeId = ingridientDto.RecipeId
            };
        }
    }
}

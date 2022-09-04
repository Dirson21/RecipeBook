using Application.Dto;
using Domain;
using Domain.Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Builders
{
    public interface IRecipeActionBuilder
    {
        public RecipeDto BuildActionRecipe(Recipe recipe, Guid userAccountId = new Guid());
    }
}

using Domain;
using Domain.Repositoy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    public class RecipeRepository : IRecipeRepository
    {

        private readonly RecipeBookDbContext _dbContext;

        public RecipeRepository(RecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Recipe Create(Recipe recipe)
        {

            return _dbContext.Recipe.Add(recipe).Entity;
        }

        public void Delete(Recipe recipe)
        {
            _dbContext.Recipe.Remove(recipe);
        }

        public List<Recipe> GetAll()
        {
            return _dbContext.Recipe.AsSplitQuery().OrderBy(x => x.Id).Include(x => x.CookingSteps)
                .Include(x => x.IngredientHeaders).ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount).ToList();
        }
        public List<Recipe> GetAll(int start, int count)
        {
            return _dbContext.Recipe.AsSplitQuery().OrderBy(x => x.Id).Skip(start).Take(count).Include(x => x.CookingSteps)
                .Include(x => x.IngredientHeaders).ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount).ToList();
        }

        public Recipe GetById(int id)
        {
            return _dbContext.Recipe.AsSplitQuery().Include(x => x.CookingSteps).Include(x => x.IngredientHeaders).
                ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount).FirstOrDefault(x => x.Id == id);
        }

        public Recipe GetByName(string name)
        {
           return _dbContext.Recipe.AsSplitQuery().Include(x => x.CookingSteps).Include(x => x.IngredientHeaders).
                ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount).FirstOrDefault(x => x.Name == name);
        }

        public Recipe Update(Recipe recipe)
        {
            return _dbContext.Recipe.Update(recipe).Entity;
        }

    }
}

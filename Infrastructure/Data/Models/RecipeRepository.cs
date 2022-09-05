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
                .Include(x => x.IngredientHeaders).ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                .Include(x => x.UserFavorites).Include(x => x.UserLikes).ToList();
        }
        public List<Recipe> GetAll(int start, int count)
        {
            return _dbContext.Recipe.AsSplitQuery().OrderBy(x => x.Id).Skip(start).Take(count).Include(x => x.CookingSteps)
                .Include(x => x.IngredientHeaders).ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                .Include(x => x.UserFavorites).Include(x => x.UserLikes).ToList();
        }

        public Recipe GetById(int id)
        {
            return _dbContext.Recipe.AsSplitQuery().Include(x => x.CookingSteps).Include(x => x.IngredientHeaders)
                .ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                .Include(x => x.UserFavorites).Include(x => x.UserLikes).FirstOrDefault(x => x.Id == id);
        }

        public Recipe GetByName(string name)
        {
            return _dbContext.Recipe.AsSplitQuery().Include(x => x.CookingSteps).Include(x => x.IngredientHeaders).
                 ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                 .Include(x => x.UserFavorites).Include(x => x.UserLikes).FirstOrDefault(x => x.Name == name);
        }

        public Recipe Update(Recipe recipe)
        {
            return _dbContext.Recipe.Update(recipe).Entity;
        }

        public int CountFavorite(Recipe recipe)
        {
            return _dbContext.Recipe.AsSingleQuery().Where(s => s.Id == recipe.Id).SelectMany(s => s.UserFavorites).Count();
        }

        public int CountLike(Recipe recipe)
        {
            return _dbContext.Recipe.AsSingleQuery().Where(s => s.Id == recipe.Id).SelectMany(recipe => recipe.UserLikes).Count();
        }

        public void Like(Recipe recipe, UserAccount userAccount)
        {
            recipe.UserLikes.Add(userAccount);
            _dbContext.Recipe.Update(recipe);
        }

        public void Favorite(Recipe recipe, UserAccount userAccount)
        {
            recipe.UserFavorites.Add(userAccount);
            _dbContext.Recipe.Update(recipe);
        }

        public void RemoveLike(Recipe recipe, UserAccount userAccount)
        {
            recipe.UserLikes.Remove(userAccount);
            _dbContext.Recipe.Update(recipe);
        }
        public void RemoveFavorite(Recipe recipe, UserAccount userAccount)
        {
            recipe.UserFavorites.Remove(userAccount);
            _dbContext.Recipe.Update(recipe);
        }


        public bool IsLike(Recipe recipe, UserAccount userAccount)
        {
            return _dbContext.Recipe.AsSingleQuery().Where(s => s.Id == recipe.Id).SelectMany(recipe => recipe.UserLikes).Where(s => s.Id == userAccount.Id).Count() > 0;
        }

        public bool IsFavorite(Recipe recipe, UserAccount userAccount)
        {
            return _dbContext.Recipe.AsSingleQuery().Where(s => s.Id == recipe.Id).SelectMany(recipe => recipe.UserFavorites).Where(s => s.Id == userAccount.Id).Count() > 0;
        }
    }
}

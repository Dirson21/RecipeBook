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
        private readonly DbSet<Recipe> _recipe;
        private DbSet<RecipeDay> _recipeDay;

        public RecipeRepository(RecipeBookDbContext dbContext)
        {
            _recipe = dbContext.Set<Recipe>();
            _recipeDay = dbContext.Set<RecipeDay>();
        }

        public Recipe Create(Recipe recipe)
        {
            return _recipe.Add(recipe).Entity;
        }

        public void Delete(Recipe recipe)
        {
            _recipe.Remove(recipe);
        }

        public List<Recipe> GetAll()
        {
            return _recipe.AsSplitQuery().OrderBy(x => x.Id).Include(x => x.CookingSteps)
                .Include(x => x.IngredientHeaders).ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                .Include(x => x.UserFavorites).Include(x => x.UserLikes).ToList();
        }
        public List<Recipe> GetAll(int start, int count)
        {
            return _recipe.AsSplitQuery().OrderBy(x => x.Id).Skip(start).Take(count).Include(x => x.CookingSteps)
                .Include(x => x.IngredientHeaders).ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                .Include(x => x.UserFavorites).Include(x => x.UserLikes).ToList();
        }

        public Recipe GetById(int id)
        {
            return _recipe.AsSplitQuery().Include(x => x.CookingSteps).Include(x => x.IngredientHeaders)
                .ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                .Include(x => x.UserFavorites).Include(x => x.UserLikes).FirstOrDefault(x => x.Id == id);
        }

        public Recipe GetByName(string name)
        {
            return _recipe.AsSplitQuery().Include(x => x.CookingSteps).Include(x => x.IngredientHeaders).
                 ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                 .Include(x => x.UserFavorites).Include(x => x.UserLikes).FirstOrDefault(x => x.Name == name);
        }

        public Recipe Update(Recipe recipe)
        {
            return _recipe.Update(recipe).Entity;
        }

        public int CountFavorite(Recipe recipe)
        {
            return _recipe.AsSplitQuery().Include(s => s.UserFavorites).Single(r => r.Id == recipe.Id).UserFavorites.Count();
        }

        public int CountLike(Recipe recipe)
        {
            return _recipe.AsSplitQuery().Include(s => s.UserLikes).Single(r => r.Id == recipe.Id).UserLikes.Count();
        }

        public void Like(Recipe recipe, UserAccount userAccount)
        {
            recipe.UserLikes.Add(userAccount);
            _recipe.Update(recipe);
        }

        public void Favorite(Recipe recipe, UserAccount userAccount)
        {
            recipe.UserFavorites.Add(userAccount);
            _recipe.Update(recipe);
        }

        public void RemoveLike(Recipe recipe, UserAccount userAccount)
        {
            recipe.UserLikes.Remove(userAccount);
            _recipe.Update(recipe);
        }
        public void RemoveFavorite(Recipe recipe, UserAccount userAccount)
        {
            recipe.UserFavorites.Remove(userAccount);
            _recipe.Update(recipe);
        }

        public bool IsLike(Recipe recipe, UserAccount userAccount)
        {
            return _recipe.AsSplitQuery().Include(r => r.UserLikes).Single(r => r.Id == recipe.Id).UserLikes.FindIndex(u => u.Id == userAccount.Id) > -1;
        }

        public bool IsFavorite(Recipe recipe, UserAccount userAccount)
        {
            return _recipe.AsSplitQuery().Include(r => r.UserFavorites).Single(r => r.Id == recipe.Id).UserFavorites.FindIndex(u => u.Id == userAccount.Id) > -1;
        }

        public List<Recipe> SearchByName(string name)
        {
           return _recipe.AsSplitQuery().Where(r => r.Name.Contains(name)).Include(x => x.CookingSteps).Include(x => x.IngredientHeaders).
                 ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                 .Include(x => x.UserFavorites).Include(x => x.UserLikes).ToList();
        }


        public Recipe GetRandom()
        {
            int skip = new Random().Next(0, _recipe.Count() - 1);

            return _recipe.Skip(skip).Take(1).Include(x => x.CookingSteps).Include(x => x.IngredientHeaders).
                 ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                 .Include(x => x.UserFavorites).Include(x => x.UserLikes).FirstOrDefault();
        }

        public RecipeDay CreateRecipeDay(Recipe recipe)
        {
            RecipeDay recipeDay = new RecipeDay();
            recipeDay.Recipe = recipe;

            return _recipeDay.Add(recipeDay).Entity;
        }

        public RecipeDay GetRecipeDay(DateTime date)
        {
            return _recipeDay.AsSplitQuery().Include(x => x.Recipe).ThenInclude(x => x.CookingSteps)
                .Include(x => x.Recipe).ThenInclude(x => x.IngredientHeaders).ThenInclude(x => x.Ingredients)
                .Include(x => x.Recipe).ThenInclude(x => x.Tags)
                .Include(x => x.Recipe).ThenInclude(x => x.UserAccount)
                .SingleOrDefault(x => x.Date.Date == date.Date);
        }
    }



}

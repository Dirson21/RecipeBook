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
        private readonly DbSet<RecipeDay> _recipeDay;
        private readonly DbSet<RecipeFavorite> _recipeFavorite;
        private readonly DbSet<RecipeLike> _recipeLike;

        public RecipeRepository(RecipeBookDbContext dbContext)
        {
            _recipe = dbContext.Set<Recipe>();
            _recipeDay = dbContext.Set<RecipeDay>();
            _recipeFavorite = dbContext.Set<RecipeFavorite>();
            _recipeLike = dbContext.Set<RecipeLike>();
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

        public Recipe GetRecipeDay(DateTime date)
        {
            var likesOfDay = _recipeLike.Include(x => x.Recipe).Where(x => x.Date.Date == date.Date);
            Dictionary<Recipe, int> recipeLikeCount = CountRecipeFromAction(likesOfDay);

            var favoriteOfDay = _recipeFavorite.Include(x => x.Recipe).Where(x => x.Date.Date == date.Date);
            Dictionary<Recipe, int> recipeFavoriteCount = CountRecipeFromAction(favoriteOfDay);

        

            Dictionary<Recipe, int> recipeRating = RecipeDayRating(recipeLikeCount, recipeFavoriteCount);
            int maxRating = recipeRating.Count > 0? recipeRating.Max(x => x.Value): 0;


            Recipe recipeDay = recipeRating.FirstOrDefault(x => x.Value == maxRating).Key;
            if (recipeDay != null)
            {
                return _recipe.AsSplitQuery().Include(x => x.CookingSteps).Include(x => x.IngredientHeaders)
                .ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                .Include(x => x.UserFavorites).Include(x => x.UserLikes)
                .FirstOrDefault(x => x.Id == recipeDay.Id);
            }

            return null;


        }


        private Dictionary<Recipe, int> CountRecipeFromAction(IQueryable<RecipeLike> recipeLike)
        {
            Dictionary<Recipe, int> actionCount = new Dictionary<Recipe, int>();

            foreach (var item in recipeLike)
            {
                actionCount[item.Recipe] = actionCount.GetValueOrDefault(item.Recipe, 0) + 1;
            }
            return actionCount;

        }
        private Dictionary<Recipe, int> CountRecipeFromAction(IQueryable<RecipeFavorite> recipeLike)
        {
            Dictionary<Recipe, int> actionCount = new Dictionary<Recipe, int>();

            foreach (var item in recipeLike)
            {
                actionCount[item.Recipe] = actionCount.GetValueOrDefault(item.Recipe, 0) + 1;
            }
            return actionCount;

        }

        private Dictionary<Recipe, int> RecipeDayRating(Dictionary<Recipe, int> recipeLikeCount, Dictionary<Recipe, int> recipeFavoriteCount)
        {
            Dictionary<Recipe, int> res = recipeLikeCount;

            foreach (var item in recipeFavoriteCount)
            {
                res[item.Key] = res.GetValueOrDefault(item.Key, 0) + 2;
            }


            return res;
        }
    }


   



}

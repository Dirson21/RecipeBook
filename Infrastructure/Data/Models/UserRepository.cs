using Domain;
using Domain.Repository;
using Domain.Repositoy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly RecipeBookDbContext _dbContext;

        private readonly IRecipeRepository _recipeRepository;

        public UserRepository(RecipeBookDbContext dbContext, IRecipeRepository recipeRepository)
        {
            _dbContext = dbContext;
            _recipeRepository = recipeRepository;
        }

        public UserAccount Create(UserAccount user)
        {
            return _dbContext.Users.Add(user).Entity;
        }

        public UserAccount GetByLogin(string login)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Name == login);
        }

        public List<Recipe> GetUserFavoriteRecipes(UserAccount user)
        {
            return _dbContext.Users.AsSplitQuery().Where(u => u.Id == user.Id).SelectMany(u => u.RecipeFavorites).Include(x => x.CookingSteps)
                .Include(x => x.IngredientHeaders).ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                .Include(x => x.UserFavorites).Include(x => x.UserLikes).ToList();
        }

        public int GetUserFavoriteRecipesCount(UserAccount user)
        {
            return _dbContext.Users.Where(u => u.Id == user.Id).SelectMany(u => u.RecipeFavorites).Count();
        }

        public List<Recipe> GetUserRecipes(UserAccount user)
        {
            return _dbContext.Users.AsSplitQuery().Where(u => u.Id == user.Id).SelectMany(u => u.UserRecipes).Include(x => x.CookingSteps)
                .Include(x => x.IngredientHeaders).ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                .Include(x => x.UserFavorites).Include(x => x.UserLikes).ToList();
        }

        public int GetUserLikesCount(UserAccount user)
        {
            int count = 0;
            foreach(var recipe in _dbContext.Users.Where(u => u.Id == user.Id).SelectMany(u => u.UserRecipes).ToList())
            {
                count += _recipeRepository.CountLike(recipe);
            }

            return count;
        }
    }
}

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
 
        private readonly DbSet<UserAccount> _user;

        public UserRepository(RecipeBookDbContext dbContext)
        {
            _user = dbContext.Set<UserAccount>();
        }

        public UserAccount Create(UserAccount user)
        {
            return _user.Add(user).Entity;
        }

        public UserAccount GetByLogin(string login)
        {
            return _user.FirstOrDefault(x => x.Name == login);
        }

        public List<Recipe> GetUserFavoriteRecipes(UserAccount user)
        {
            return _user.AsSplitQuery().Where(u => u.Id == user.Id).SelectMany(u => u.RecipeFavorites).Include(x => x.CookingSteps)
                .Include(x => x.IngredientHeaders).ThenInclude(x => x.Ingredients).Include(x => x.Tags).Include(x => x.UserAccount)
                .Include(x => x.UserFavorites).Include(x => x.UserLikes).ToList();
        }

        public int GetUserFavoriteRecipesCount(UserAccount user)
        {
            return _user.Include(u => u.UserRecipes).ThenInclude(r => r.UserFavorites).Single(u => u.Id == user.Id).UserRecipes.Sum(x => x.UserFavorites.Count());
        }

        public List<Recipe> GetUserRecipes(UserAccount user)
        {
            return _user.AsSplitQuery().Include(u => u.UserRecipes).ThenInclude(r => r.CookingSteps)
                .Include(u => u.UserRecipes).ThenInclude(r => r.IngredientHeaders).ThenInclude(i => i.Ingredients)
                .Include(u => u.UserRecipes).ThenInclude(r => r.Tags)
                .Single(u => u.Id == user.Id).UserRecipes;
        }

        public int GetUserLikesCount(UserAccount user)
        {
            return _user.Include(u => u.UserRecipes).ThenInclude(r => r.UserLikes).Single(u => u.Id == user.Id).UserRecipes.Sum(x => x.UserLikes.Count());
        }
    }
}

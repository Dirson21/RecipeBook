using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        public UserAccount Create(UserAccount user);
        public UserAccount GetByLogin(string login);

        public List<Recipe> GetUserRecipes(UserAccount user);

       
        public List<Recipe> GetUserFavoriteRecipes(UserAccount user);

        public int GetUserFavoriteRecipesCount(UserAccount user);
        public int GetUserLikesCount(UserAccount user);


    }
}

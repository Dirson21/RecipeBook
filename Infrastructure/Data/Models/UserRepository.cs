using Domain;
using Domain.Repository;
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

        public UserRepository(RecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetByLogin(string login)
        {
            return _dbContext.User.FirstOrDefault(x => x.Login == login);
        }

        public User Create(User user)
        {
            return _dbContext.User.Add(user).Entity;
        }
    }
}

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

       
    }
}

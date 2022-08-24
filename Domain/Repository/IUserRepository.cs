using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByLogin(string login);
    }
}

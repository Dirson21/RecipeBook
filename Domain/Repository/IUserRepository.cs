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
    }
}

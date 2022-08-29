using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IJwtGenerator
    {
        string CreateToken(UserAccount user);

        Guid getNameId(string token);

    }
}


using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserAccount : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Recipe> UserRecipes { get; set; } = new List<Recipe>();
    }
}

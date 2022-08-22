using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

/*        List<Recipe> RecipeLikes { get; set; } 

        List<Recipe> UserRecipes { get; set; }

        List<Recipe> RecipeFavorite { get; set; }*/
    }
}

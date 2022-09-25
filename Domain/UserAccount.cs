
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class UserAccount : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Recipe> UserRecipes { get; set; } = new List<Recipe>();

        public virtual List<Recipe> RecipeLikes { get; set; } = new List<Recipe>();

        public virtual List<Recipe> RecipeFavorites { get; set; } = new List<Recipe>();
    }
}

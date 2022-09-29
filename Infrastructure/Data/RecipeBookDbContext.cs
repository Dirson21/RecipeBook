using Domain;
using Domain.UoW;
using Infrastructure.Data.Models.EntityConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RecipeBookDbContext : IdentityDbContext<UserAccount, IdentityRole<Guid>, Guid>, IUnitOfWork
    {
        public RecipeBookDbContext(DbContextOptions<RecipeBookDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RecipeMap());
            builder.ApplyConfiguration(new IngredientMap());
            builder.ApplyConfiguration(new CookingStepMap());
            builder.ApplyConfiguration(new TagMap());
            builder.ApplyConfiguration(new IngredientHeaderMap());
            builder.ApplyConfiguration(new UserAccountMap());

        }

        public int Commit()
        {
            return SaveChanges();
        }
    }
}

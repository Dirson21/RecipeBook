using Domain;
using Domain.UoW;
using Infrastructure.Data.Models.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class RecipeBookDbContext : DbContext, IUnitOfWork
    {

        public RecipeBookDbContext(DbContextOptions<RecipeBookDbContext> options): base(options)
        {

        }

        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<CookingStep> CookingStep { get; set; }

        public DbSet<IngredientHeader> IngredientHeader { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RecipeMap());
            builder.ApplyConfiguration(new IngredientMap());
            builder.ApplyConfiguration(new CookingStepMap());
            builder.ApplyConfiguration(new TagMap());
            builder.ApplyConfiguration(new IngredientHeaderMap());
           
        }

        public int Commit()
        {
            return SaveChanges();
        }
    }
}

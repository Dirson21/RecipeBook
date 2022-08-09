using Domain;
using Infrastructure.Data.Models.EntityConfigurations;
using Infrastructure.UoW;
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
        public DbSet<Ingridient> Ingridient { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CookingStep> CookingStep { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RecipeMap());
            builder.ApplyConfiguration(new IngridientMap());
            builder.ApplyConfiguration(new CookingStepMap());
            builder.ApplyConfiguration(new TagMap());
        }

        public int Commit()
        {
            return SaveChanges();
        }
    }
}

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models.EntityConfigurations
{
    public class RecipeMap : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name);

            builder.Property(x => x.Image);

            builder.Property(x => x.Description);

            builder.Property(x => x.CookingTime);

            builder.Property(x => x.CountPerson);

            builder.Property(x => x.UserAccountId);

            builder.HasOne(x => x.UserAccount).WithMany(x => x.UserRecipes).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.UserAccountId);

  

        }
    }
}

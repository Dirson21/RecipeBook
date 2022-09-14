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
    public class RecipeDayMap : IEntityTypeConfiguration<RecipeDay>
    {
        public void Configure(EntityTypeBuilder<RecipeDay> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.RecipeId);

            builder.Property(x => x.Date);
            builder.HasOne(x => x.Recipe).WithOne().OnDelete(DeleteBehavior.Cascade).HasForeignKey<RecipeDay>(x => x.RecipeId);

        }
    }
}

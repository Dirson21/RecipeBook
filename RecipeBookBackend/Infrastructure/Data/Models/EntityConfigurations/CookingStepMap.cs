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
    public class CookingStepMap : IEntityTypeConfiguration<CookingStep>
    {
        public void Configure(EntityTypeBuilder<CookingStep> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Recipe).WithMany(x => x.CookingSteps).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.RecipeId);

            builder.Property(x => x.RecipeId);

            builder.Property(x => x.Description);

        }
    }
}

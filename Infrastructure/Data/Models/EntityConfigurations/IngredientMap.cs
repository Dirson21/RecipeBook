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
    public class IngredientMap : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
           

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.IngridientHeaderId);
            builder.HasOne(x => x.IngredientHeader).WithMany(x => x.Ingredients).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.IngridientHeaderId);

        }
    }
}

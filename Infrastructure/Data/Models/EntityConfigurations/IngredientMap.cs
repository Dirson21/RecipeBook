using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Models.EntityConfigurations
{
    public class IngredientMap : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.IngredientHeaderId);
            builder.HasOne(x => x.IngredientHeader).WithMany(x => x.Ingredients)
                .OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.IngredientHeaderId);

        }
    }
}

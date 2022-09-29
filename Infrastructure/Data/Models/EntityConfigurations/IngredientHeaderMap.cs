using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Models.EntityConfigurations
{
    public class IngredientHeaderMap : IEntityTypeConfiguration<IngredientHeader>
    {
        public void Configure(EntityTypeBuilder<IngredientHeader> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name);

            builder.Property(x => x.RecipeId);
            builder.HasOne(x => x.Recipe).WithMany(x => x.IngredientHeaders).
                OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.RecipeId);
        }
    }
}

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Models.EntityConfigurations
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.Recipes).WithMany(x => x.Tags).UsingEntity(j => j.ToTable("RecipeTag"));

            builder.Property(x => x.Name);
            builder.HasIndex(x => x.Name).IsUnique();

        }
    }
}

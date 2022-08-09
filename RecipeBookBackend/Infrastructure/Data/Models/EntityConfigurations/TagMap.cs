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
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.Recipes).WithMany(x => x.Tags).UsingEntity(j => j.ToTable("RecipeTag"));

            builder.Property(x => x.Name);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Image);

            builder.Property(x => x.Description);

        }
    }
}

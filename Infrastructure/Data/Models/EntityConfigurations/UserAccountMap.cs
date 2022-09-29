using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Models.EntityConfigurations
{
    public class UserAccountMap : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Name).IsRequired(false);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Users;

namespace MoneyShare.Infrastructure.EntityConfiguration;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups").HasKey(g => g.Id);

        builder.HasMany<User>().WithMany();
    }
}

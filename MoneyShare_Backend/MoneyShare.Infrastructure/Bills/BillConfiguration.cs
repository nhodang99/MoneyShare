using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Users;

namespace MoneyShare.Infrastructure.Bills;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills").HasKey(b => b.Id);

        builder.Property(b => b.Price).HasColumnType("decimal(10, 0)");

        builder.HasOne<User>().WithMany()
            .HasForeignKey(b => b.PayerId);

        builder.HasOne<Group>().WithMany()
            .HasForeignKey(b => b.GroupId);
    }
}

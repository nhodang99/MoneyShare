using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Groups_Users;
using MoneyShare.Domain.Users;

namespace MoneyShare.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Group> Groups { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .Property(b => b.Price)
                .HasColumnType("decimal(10, 0)");

            modelBuilder.Entity<Group_User>().HasKey(gu => new
            {
                gu.GroupId,
                gu.UserId
            });

            modelBuilder.Entity<Group_User>().HasOne(g => g.Group)
                                              .WithMany(gu => gu.Groups_Users)
                                              .HasForeignKey(g => g.GroupId);
            modelBuilder.Entity<Group_User>().HasOne(u => u.User)
                                              .WithMany(gu => gu.Groups_Users)
                                              .HasForeignKey(u => u.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

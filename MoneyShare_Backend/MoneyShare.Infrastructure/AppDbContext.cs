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
            // Bill - Group 
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Group)
                .WithMany(g => g.Bills)
                .HasForeignKey(b => b.GroupId);

            // Bill User
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Payer)
                .WithMany(u => u.Bills)
                .HasForeignKey(b => b.PayerId);

            // Groups - Users many to many 
            modelBuilder.Entity<Group_User>().HasKey(gu => new
            {
                gu.GroupId,
                gu.UserId
            });

            modelBuilder.Entity<Group_User>()
                .HasOne(gu => gu.Group)
                .WithMany(g => g.Groups_Users)
                .HasForeignKey(gu => gu.GroupId);

            modelBuilder.Entity<Group_User>()
                .HasOne(u => u.User)
                .WithMany(gu => gu.Groups_Users)
                .HasForeignKey(u => u.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

#region

using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneyShare.Application.Models;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Users;
using SharedKernel;

#endregion

namespace MoneyShare.Infrastructure.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options, IPublisher publisher)
    : IdentityDbContext<ApplicationUser>(options)
{
    public new DbSet<User> Users { get; set; } // Domain user
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Group> Groups { get; set; }

    private readonly IPublisher _publisher = publisher;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Bill>()
            .Property(b => b.Price).HasColumnType("decimal(10, 0)");

        modelBuilder.Entity<Group>()
            .Property(g => g.Name).HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.UserName).HasMaxLength(50);

        // For identity
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // When should you publish domain events?
        //
        // 1. BEFORE calling SaveChangesAsync
        //     - domain events are part of the same transaction
        //     - immediate consistency
        // 2. AFTER calling SaveChangesAsync
        //     - domain events are a separate transaction
        //     - eventual consistency
        //     - handlers can fail

        int result = await base.SaveChangesAsync(cancellationToken);

        await PublishDomainEventsAsync();

        return result;
    }

    private async Task PublishDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<EntityBase>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                List<DomainEvent> domainEvents = entity.DomainEvents;

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach (DomainEvent domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }
}
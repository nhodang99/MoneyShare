using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Users;
using SharedKernel;

namespace MoneyShare.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Group> Groups { get; set; }


    private readonly IPublisher _publisher;

    public AppDbContext(DbContextOptions<AppDbContext> options, IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>()
            .Property(b => b.Price).HasColumnType("decimal(10, 0)");

        modelBuilder.Entity<Group>()
            .Property(g => g.Name).HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.UserName).HasMaxLength(50);

        base.OnModelCreating(modelBuilder);
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

using MediatR;

namespace SharedKernel;

/// <summary>
/// A base type for domain events. Depends on MediatR INotification.
/// Includes DateOccurred which is set on creation.
/// </summary>
public abstract record DomainEvent : INotification
{
  public DateTime DateOccurred { get; init; } = DateTime.UtcNow;
}


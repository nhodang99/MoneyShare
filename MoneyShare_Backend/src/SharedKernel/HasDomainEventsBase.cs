using System.ComponentModel.DataAnnotations.Schema;

namespace SharedKernel;

public abstract class HasDomainEventsBase
{
    private readonly List<DomainEvent> _domainEvents = [];

    [NotMapped]
    public List<DomainEvent> DomainEvents => [.. _domainEvents];

    public void RegisterDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}

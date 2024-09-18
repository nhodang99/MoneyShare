using SharedKernel;

namespace MoneyShare.Domain.Users.Events;

internal sealed record UserDeletedDomainEvent(Guid UserId) : DomainEvent;

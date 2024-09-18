using SharedKernel;

namespace MoneyShare.Domain.Users.Events;

internal sealed record UserRegisteredDomainEvent(Guid UserId) : DomainEvent;

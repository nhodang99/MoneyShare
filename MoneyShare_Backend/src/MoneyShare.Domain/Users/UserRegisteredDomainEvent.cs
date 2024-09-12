using SharedKernel;

namespace MoneyShare.Domain.Users;

public sealed record UserRegisteredDomainEvent(Guid UserId) : DomainEvent;

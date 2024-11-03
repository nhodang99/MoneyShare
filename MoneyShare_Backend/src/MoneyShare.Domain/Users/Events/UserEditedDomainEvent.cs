using SharedKernel;

namespace MoneyShare.Domain.Users.Events;

public sealed record UserEditedDomainEvent(Guid Id) : DomainEvent;

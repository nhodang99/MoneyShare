using SharedKernel;

namespace MoneyShare.Domain.Users.Events;

internal sealed record UserEditedDomainEvent(Guid Id) : DomainEvent;

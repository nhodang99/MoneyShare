#region

using SharedKernel;

#endregion

namespace MoneyShare.Domain.Users.Events;

public sealed record UserRegisteredDomainEvent(Guid UserId) : DomainEvent;
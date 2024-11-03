#region

using SharedKernel;

#endregion

namespace MoneyShare.Domain.Users.Events;

public sealed record UserDeletedDomainEvent(Guid UserId) : DomainEvent;
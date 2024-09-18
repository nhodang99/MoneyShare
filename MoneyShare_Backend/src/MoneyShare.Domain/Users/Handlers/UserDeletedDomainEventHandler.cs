using MediatR;
using Microsoft.Extensions.Logging;
using MoneyShare.Domain.Users.Events;

namespace MoneyShare.Domain.Users.Handlers;

internal sealed class UserDeletedDomainEventHandler(ILogger<UserDeletedDomainEventHandler> logger)
    : INotificationHandler<UserDeletedDomainEvent>
{
    public Task Handle(UserDeletedDomainEvent notification, CancellationToken cancellationToken)
    {
        // TODO: Send an email invitation link. logout...
        logger.LogDebug("A user registered");
        return Task.CompletedTask;
    }
}

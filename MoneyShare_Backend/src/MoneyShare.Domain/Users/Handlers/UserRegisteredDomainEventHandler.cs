using MediatR;
using Microsoft.Extensions.Logging;
using MoneyShare.Domain.Users.Events;

namespace MoneyShare.Domain.Users.Handlers;

internal sealed class UserRegisteredDomainEventHandler(ILogger<UserRegisteredDomainEventHandler> logger)
    : INotificationHandler<UserRegisteredDomainEvent>
{
    public Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        // TODO: Send an email invitation link.
        logger.LogDebug("A user registered");
        return Task.CompletedTask;
    }
}

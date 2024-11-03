#region

using MediatR;
using Microsoft.Extensions.Logging;
using MoneyShare.Domain.Users.Events;

#endregion

namespace MoneyShare.Application.DomainEventHandlers;

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
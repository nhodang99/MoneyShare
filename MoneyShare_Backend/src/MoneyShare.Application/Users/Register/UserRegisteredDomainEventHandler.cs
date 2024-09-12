using MediatR;
using Microsoft.Extensions.Logging;
using MoneyShare.Domain.Users;

namespace MoneyShare.Application.Users.Register;

internal sealed class UserRegisteredDomainEventHandler(ILogger<UserRegisteredDomainEventHandler> logger)
    : INotificationHandler<UserRegisteredDomainEvent>
{
    public Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        // TODO: Send an email invitation link.
        logger.LogDebug("A user has registered");
        return Task.CompletedTask;
    }
}

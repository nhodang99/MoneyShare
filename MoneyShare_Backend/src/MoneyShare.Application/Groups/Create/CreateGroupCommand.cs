#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Groups.Create;

public sealed record CreateGroupCommand(string Name) : ICommand<Guid>;
#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Groups.Delete;

public sealed record DeleteGroupCommand(Guid GroupId) : ICommand;
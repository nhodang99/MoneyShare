#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Groups.Edit;

public sealed record EditGroupCommand(Guid Id, string Name) : ICommand;
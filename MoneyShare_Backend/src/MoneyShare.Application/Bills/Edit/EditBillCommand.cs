using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Bills.Edit;

public sealed record EditBillCommand(Guid Id, string Title, decimal Price, Guid GroupId, Guid PayerId) : ICommand;

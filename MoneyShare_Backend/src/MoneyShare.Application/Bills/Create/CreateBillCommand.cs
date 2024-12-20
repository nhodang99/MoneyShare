﻿#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Bills.Create;

public sealed record CreateBillCommand(string Title, decimal Price, Guid GroupId, Guid PayerId) : ICommand<Guid>;
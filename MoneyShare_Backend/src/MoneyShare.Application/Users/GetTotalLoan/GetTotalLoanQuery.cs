#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Users.GetTotalLoan;

public record GetTotalLoanQuery(Guid UserId) : IQuery<decimal>;
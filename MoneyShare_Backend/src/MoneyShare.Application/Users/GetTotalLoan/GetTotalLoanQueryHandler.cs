#region

using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Users.GetTotalLoan;

internal sealed class GetTotalLoanQueryHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetTotalLoanQuery, decimal>
{
    public async Task<Result<decimal>> Handle(GetTotalLoanQuery query, CancellationToken cancellationToken)
    {
        return await unitOfWork.Users.GetTotalLoan(query.UserId);
    }
}
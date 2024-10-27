#region

using MediatR;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Interfaces.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
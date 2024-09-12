using MediatR;
using SharedKernel;

namespace MoneyShare.Application.Contracts.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;

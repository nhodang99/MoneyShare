﻿using MediatR;
using SharedKernel;

namespace MoneyShare.Application.Contracts.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;

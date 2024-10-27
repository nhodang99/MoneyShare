﻿#region

using MediatR;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Interfaces.Messaging;

public interface ICommandHandler<in TCommand>
    : IRequestHandler<TCommand, Result>
    where TCommand : ICommand;

public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>;
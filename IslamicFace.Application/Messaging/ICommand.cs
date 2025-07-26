using MediatR;
using IslamicFace.Application;
using IslamicFace.Application.ErrorHandleClasses;


namespace IslamicFace.Application.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;

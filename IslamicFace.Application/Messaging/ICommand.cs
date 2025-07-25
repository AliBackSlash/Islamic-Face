using MediatR;
using IslamicFace.Domain;
using IslamicFace.Domain.ErrorHandleClasses;


namespace IslamicFace.Application.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;

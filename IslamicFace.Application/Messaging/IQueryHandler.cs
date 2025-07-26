using MediatR;
using IslamicFace.Application;
using IslamicFace.Application.ErrorHandleClasses;
namespace IslamicFace.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;

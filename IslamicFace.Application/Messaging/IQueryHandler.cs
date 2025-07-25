using MediatR;
using IslamicFace.Domain;
using IslamicFace.Domain.ErrorHandleClasses;
namespace IslamicFace.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;

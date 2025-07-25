using MediatR;
using IslamicFace.Domain.ErrorHandleClasses;


namespace IslamicFace.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;

using MediatR;
using IslamicFace.Application.ErrorHandleClasses;


namespace IslamicFace.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;

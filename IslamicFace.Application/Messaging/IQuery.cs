using MediatR;


namespace IslamicFace.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;

using Library.Domain.Abstractions;
using MediatR;

namespace Library.Application.Abstractions.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}

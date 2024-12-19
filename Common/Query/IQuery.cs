using MediatR;

namespace Common.Query;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
{
}
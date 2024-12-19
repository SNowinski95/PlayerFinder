using MediatR;

namespace Common.Command;

public interface ICommand : IRequest<Result>
{
    
}
public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
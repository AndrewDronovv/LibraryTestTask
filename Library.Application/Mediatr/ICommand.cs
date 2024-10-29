using MediatR;

namespace Library.Application.Mediatr
{
    public interface ICommand<out TResponse> : IRequest<TResponse> 
    { 

    }
}

using MediatR;

namespace Library.Application.Mediatr
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {

    }
}

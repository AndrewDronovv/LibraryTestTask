using Library.Application.Dto.Books;
using Library.Application.Mediatr;

namespace Library.Application.Books.Queries.Get
{
    public class GetBookQuery : IQuery<BookDto>
    {
        public int Id { get; }

        public GetBookQuery(int id)
        {
            Id = id;
        }
    }
}

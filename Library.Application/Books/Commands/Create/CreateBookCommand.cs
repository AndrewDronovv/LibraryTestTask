using Library.Application.Dto.Books;
using Library.Application.Mediatr;
using Library.Domain.Enums;

namespace Library.Application.Books.Commands.Create
{
    public class CreateBookCommand : ICommand<CreateBookDto>
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublishedYear { get; set; }
        public Genre Genre { get; set; }
    }
}
using Library.Application.Dto.Books;
using Library.Application.Mediatr;
using Library.Domain.Enums;

namespace Library.Application.Books.Commands.Update
{
    public class UpdateBookCommand : ICommand<UpdateBookDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublishedYear { get; set; }
        public Genre Genre { get; set; }
    }
}

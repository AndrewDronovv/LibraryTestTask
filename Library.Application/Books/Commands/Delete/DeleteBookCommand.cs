using Library.Application.Mediatr;
using Library.Domain.Entities;

namespace Library.Application.Books.Commands.Delete
{
    public class DeleteBookCommand : ICommand<Book>
    {
        public int Id { get; set; }

        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}

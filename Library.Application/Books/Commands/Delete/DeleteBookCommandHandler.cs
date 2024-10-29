using AutoMapper;
using Library.Application.Mediatr;
using Library.Domain;
using Library.Domain.Entities;

namespace Library.Application.Books.Commands.Delete
{
    public class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand, Book>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public DeleteBookCommandHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Book> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Book book = await _context.Books.FindAsync(request.Id);

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}

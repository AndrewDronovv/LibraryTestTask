using AutoMapper;
using Library.Application.Dto.Books;
using Library.Application.Mediatr;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Commands.Update
{
    public class UpdateBookCommandHandler : ICommandHandler<UpdateBookCommand, UpdateBookDto>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public UpdateBookCommandHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UpdateBookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == request.Id);

            _mapper.Map(request, book);
            _context.Books.Update(book);
            await _context.SaveChangesAsync(cancellationToken);

            var bookDto = _mapper.Map<UpdateBookDto>(book);
            return bookDto;
        }
    }
}

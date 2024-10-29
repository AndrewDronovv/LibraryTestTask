using AutoMapper;
using Library.Application.Dto.Books;
using Library.Application.Mediatr;
using Library.Domain;
using Library.Domain.Entities;

namespace Library.Application.Books.Commands.Create
{
    public class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, CreateBookDto>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CreateBookCommandHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CreateBookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Book>(request);
            await _context.Books.AddAsync(result, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var bookDto = _mapper.Map<CreateBookDto>(result);
            return bookDto;
        }
    }
}

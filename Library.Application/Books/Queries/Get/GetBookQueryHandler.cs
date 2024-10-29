using AutoMapper;
using Library.Application.Dto.Books;
using Library.Application.Mediatr;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.Get
{
    public class GetBookQueryHandler : IQueryHandler<GetBookQuery, BookDto>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public GetBookQueryHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            var result = _mapper.Map<BookDto>(book);
            return result;
        }
    }
}

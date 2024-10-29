using AutoMapper;
using Library.Application.Dto.Books;
using Library.Application.Mediatr;
using Library.Domain;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Quaries.GetAll
{
    public class GetAllBookQueryHandler : IQueryHandler<GetAllBookQuery, IReadOnlyList<BookDto>>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public GetAllBookQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BookDto>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Book> books = await _context.Books.Include(b => b.Author).ToListAsync();
            var result = _mapper.Map<IReadOnlyList<BookDto>>(books);
            return result;
        }
    }
}
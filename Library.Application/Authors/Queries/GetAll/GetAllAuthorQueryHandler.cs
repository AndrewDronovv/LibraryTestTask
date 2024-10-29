using AutoMapper;
using Library.Application.Dto.Authors;
using Library.Application.Mediatr;
using Library.Domain;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Authors.Queries.GetAll
{
    public class GetAllAuthorQueryHandler : IQueryHandler<GetAllAuthorQuery, IReadOnlyList<AuthorDto>>
    {
        private readonly IMapper _mapper;

        private readonly AppDbContext _context;

        public GetAllAuthorQueryHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IReadOnlyList<AuthorDto>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Author> authors = await _context.Authors.ToListAsync();
            var result = _mapper.Map<IReadOnlyList<AuthorDto>>(authors);
            return result;
        }
    }
}

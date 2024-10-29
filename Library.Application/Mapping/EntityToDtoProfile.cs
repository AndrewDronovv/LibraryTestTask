using AutoMapper;
using Library.Application.Dto.Authors;
using Library.Application.Dto.Books;
using Library.Domain.Entities;

namespace Library.Application.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.FullName));
            CreateMap<Book, UpdateBookDto>();
            CreateMap<Book, CreateBookDto>();
            CreateMap<Author, AuthorDto>();
        }
    }
}
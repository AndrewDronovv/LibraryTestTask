using AutoMapper;
using Library.Application.Books.Commands.Create;
using Library.Application.Books.Commands.Update;
using Library.Application.Dto.Books;
using Library.Domain.Entities;

namespace Library.Application.Mapping
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<CreateBookDto, CreateBookCommand>();
            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookDto, Book>();
            CreateMap<UpdateBookDto, UpdateBookCommand>();
            CreateMap<UpdateBookCommand, Book>();
        }
    }
}

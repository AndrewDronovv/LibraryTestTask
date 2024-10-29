using FluentValidation;
using Library.Application.Dto.Books;

namespace Library.Application.FluentValidation
{
    public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Название книги не должно быть пустым")
                .Length(2, 50).WithMessage("Название книги должно быть от 2 до 50 символов");

            RuleFor(b => b.AuthorId)
                .NotNull().WithMessage("Id Автора не может быть пустым")
                .GreaterThan(0).WithMessage("Id Автора должно быть больше 0");

            RuleFor(b => b.PublishedYear)
                .InclusiveBetween(1800, DateTime.Now.Year)
                .WithMessage($"Год публикации должен быть от 1800 до {DateTime.Now.Year}");

            RuleFor(b => b.Genre)
                .NotNull().WithMessage("Жанр книги не должен быть пустым")
                .IsInEnum().WithMessage("Недопустимые жанр книги");
        }
    }
}

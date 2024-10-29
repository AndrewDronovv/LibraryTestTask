using Library.Domain.Enums;

namespace Library.Application.Dto.Books
{
    public sealed class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public Genre Genre { get; set; }
    }
}
using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Seed;
using Library.Domain;

public class BookSeed : BaseSeed
{
    public BookSeed(AppDbContext context) : base(context)
    {
    }

    public override void Initialize()
    {
        List<Book> books = new List<Book>
            {
                new Book { Title = "Space Odyssey", AuthorId = 1, PublishedYear = 1968, Genre = Genre.Fiction },
                new Book { Title = "Love Story", AuthorId = 2, PublishedYear = 1970, Genre = Genre.Romance },
                new Book { Title = "Ancient Tales", AuthorId = 3, PublishedYear = 1920, Genre = Genre.Classic },
                new Book { Title = "Jungle Adventure", AuthorId = 4, PublishedYear = 1950, Genre = Genre.Adventure },
                new Book { Title = "Modern Sci-Fi", AuthorId = 5, PublishedYear = 2022, Genre = Genre.Fiction }
            };

        foreach (var book in books)
        {
            if (!_context.Books.Any(b => b.Title == book.Title && b.AuthorId == book.AuthorId))
            {
                _context.Books.Add(book);
            }
        }
        _context.SaveChanges();
    }
}
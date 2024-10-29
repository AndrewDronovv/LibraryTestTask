using Library.Domain.Entities;

namespace Library.Domain.Seed
{
    public class AuthorSeed : BaseSeed
    {
        public AuthorSeed(AppDbContext context) : base(context)
        {
        }

        public override void Initialize()
        {

            List<Author> authors = new List<Author>
                {
                    new Author
                    {
                        Name = "Isaac",
                        Surname = "Asimov",
                        MiddleName = "Yudovich",
                        Birthday = new DateOnly(1920, 1, 2)
                    },
                    new Author
                    {
                        Name = "Arthur",
                        Surname = "Clarke",
                        MiddleName = "Charles",
                        Birthday = new DateOnly(1917, 12, 16)
                    },
                    new Author
                    {
                        Name = "Agatha",
                        Surname = "Christie",
                        MiddleName = "Mary Clarissa",
                        Birthday = new DateOnly(1890, 9, 15)
                    },
                    new Author
                    {
                        Name = "George",
                        Surname = "Orwell",
                        MiddleName = "Eric Arthur",
                        Birthday = new DateOnly(1903, 6, 25)
                    },
                    new Author
                    {
                        Name = "J.K.",
                        Surname = "Rowling",
                        MiddleName = "Joanne",
                        Birthday = new DateOnly(1965, 7, 31)
                    }
                };

            foreach (var author in authors)
            {
                if (!_context.Authors.Any(a => a.Name == author.Name))
                {
                    _context.Authors.Add(author);
                }
            }
            _context.SaveChanges();
        }
    }
}
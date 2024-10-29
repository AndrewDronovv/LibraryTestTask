using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

namespace Library.Domain.Seed
{
    public abstract class BaseSeed
    {
        protected readonly AppDbContext _context;

        protected BaseSeed(AppDbContext context)
        {
            _context = context;
        }

        public abstract void Initialize();
    }
}
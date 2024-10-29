using Microsoft.Extensions.DependencyInjection;

namespace Library.Domain.Seed
{
    public static class SeedHelper
    {
        public static void Initialize(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                new AuthorSeed(context).Initialize();
                new BookSeed(context).Initialize();
            }
        }
    }
}
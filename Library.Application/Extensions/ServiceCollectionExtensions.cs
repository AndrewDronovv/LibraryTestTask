using FluentValidation;
using FluentValidation.AspNetCore;
using Library.Application.Dto.Books;
using Library.Application.FluentValidation;
using Library.Application.Mapping;
using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ServiceCollectionExtensions));

            string connetrionString = configuration.GetConnectionString("Default");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connetrionString));


            services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssembly(typeof(EntityToDtoProfile).Assembly);
                c.RegisterServicesFromAssembly(typeof(DtoToEntityProfile).Assembly);
            });

            services.AddValidatorsFromAssemblyContaining<CreateBookDtoValidator>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            return services;
        }
    }
}

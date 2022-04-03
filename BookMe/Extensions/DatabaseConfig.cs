using BookMe.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookMe.API.Extensions
{
    public static class DatabaseConfig
    {
        public static IServiceCollection ConfigureDataBase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BookMeContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}

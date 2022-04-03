using BookMe.Application.Interfaces;
using BookMe.Application.Services;
using BookMe.Core.DomainServices;
using BookMe.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookMe.API.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<IHotelDomainService, HotelDoaminService>();
            return services;
        }
    }
}

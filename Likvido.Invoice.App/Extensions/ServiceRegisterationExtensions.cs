using AutoMapper;
using Likvido.Invoice.ApiClient;
using Likvido.Invoice.Data.Repositories.Interfaces;
using Likvido.Invoice.Data.UOW;
using Likvido.Invoice.Services.Profiles;
using Likvido.Invoice.Services.Services;
using Likvido.Invoice.Services.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Likvido.Invoice.App.Extensions
{
    public static class ServiceRegisterationExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }    
        
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EntityToDomainModelProfile());
                mc.AddProfile(new DomainModelToViewModel());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICountryService, CountryService>();
            return services;
        }

        public static IServiceCollection AddApiCaller(this IServiceCollection services)
        {
            services.AddScoped<IApiCaller, ApiCaller>();
            return services;
        }
    }
}

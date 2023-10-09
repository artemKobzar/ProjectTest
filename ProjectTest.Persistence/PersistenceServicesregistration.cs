using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Persistence.Repositories;

namespace ProjectTest.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection CofigurePersistenceServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectTestDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DbConnection")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPassportUserRepository, PassportUserRepository>();
            services.AddDbContext<ProjectTestDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Persistence.Repositories;
using ProjectTest.Persistence.Services;
using ProjectTest.Persistence.Services.Interfaces;
using System.Reflection;

namespace ProjectTest.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection CofigurePersistenceServices (this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ProjectTestDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DbConnection")));
            services.AddDbContext<ProjectTestDbContext>(options => 
            { options.UseSqlServer(configuration.GetConnectionString("SQLDbConnection"));
                options.EnableSensitiveDataLogging(true); 
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPassportUserRepository, PassportUserRepository>();
            services.AddScoped<IReportEventServiceRepository, ReportEventServiceRepository>();
            services.AddScoped<MessageReportService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<ISPUserRepository, SPUserRepository>();
            services.AddScoped<ISPPassportUserRepository, SPPassportUserRepository>();
            services.AddDbContext<ProjectTestDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;
        }
    }
}

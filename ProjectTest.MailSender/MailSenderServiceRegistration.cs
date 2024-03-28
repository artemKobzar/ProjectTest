using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTest.Application.Contracts.MailSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.MailSender
{
    public static class MailSenderServiceRegistration
    {
        public static IServiceCollection ConfigureMailSenderServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}

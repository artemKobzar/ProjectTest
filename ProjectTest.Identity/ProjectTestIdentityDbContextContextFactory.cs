using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Identity
{
    public class ProjectTestIdentityDbContextContextFactory: IDesignTimeDbContextFactory<ProjectTestIdentityDbContext>
    {
        public ProjectTestIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ProjectTestIdentityDbContext>();
            var connectionString = configuration.GetConnectionString("SQLDbConnectionIdentity");

            //builder.UseSqlite(connectionString);
            builder.UseSqlServer(connectionString);

            return new ProjectTestIdentityDbContext(builder.Options);
        }
    }
}

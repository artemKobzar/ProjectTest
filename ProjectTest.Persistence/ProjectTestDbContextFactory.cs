using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Domain;


namespace ProjectTest.Persistence
{
    public class ProjectTestDbContextFactory: IDesignTimeDbContextFactory<ProjectTestDbContext>
    {
        public ProjectTestDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ProjectTestDbContext>();
            var connectionString = configuration.GetConnectionString("SQLDbConnection");

            //builder.UseSqlite(connectionString);
            builder.UseSqlServer(connectionString);

            return new ProjectTestDbContext(builder.Options);
        }
    }
}

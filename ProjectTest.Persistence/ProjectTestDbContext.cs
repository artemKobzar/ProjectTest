using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Persistence.EntityTypeConfigurations;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Domain;


namespace ProjectTest.Persistence
{
    public class ProjectTestDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PassportUser> PassportUsers { get; set; }
        public ProjectTestDbContext(DbContextOptions<ProjectTestDbContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectTestDbContext).Assembly);
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>().HasKey(u => u.Id);
            //modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique();
            //modelBuilder.Entity<User>().Property(u => u.FirstName).HasMaxLength(30).IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.LastName).HasMaxLength(30).IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(100).IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.PhoneNumber).HasMaxLength(50);
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    return base.SaveChangesAsync(cancellationToken);

        //}
    }
}

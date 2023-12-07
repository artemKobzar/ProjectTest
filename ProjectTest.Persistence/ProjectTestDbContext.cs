using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Persistence.EntityTypeConfigurations;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.Convertors;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Domain;


namespace ProjectTest.Persistence
{
    public class ProjectTestDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PassportUser> PassportUsers { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventMessageResult> EventMessageResults { get; set; }
        public DbSet<UserJoinPassportDto> UserWithPassport { get; set; } 
        public ProjectTestDbContext(DbContextOptions<ProjectTestDbContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectTestDbContext).Assembly);

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<DateOnly>().HaveConversion<DateOnlyConverter>().HaveColumnType("date");
        }
    }
}
//public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
//{
//    return base.SaveChangesAsync(cancellationToken);

//}
//modelBuilder.ApplyConfiguration(new UserConfiguration());
//base.OnModelCreating(modelBuilder);

//modelBuilder.Entity<User>().HasKey(u => u.Id);
//modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique();
//modelBuilder.Entity<User>().Property(u => u.FirstName).HasMaxLength(30).IsRequired();
//modelBuilder.Entity<User>().Property(u => u.LastName).HasMaxLength(30).IsRequired();
//modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(100).IsRequired();
//modelBuilder.Entity<User>().Property(u => u.PhoneNumber).HasMaxLength(50);

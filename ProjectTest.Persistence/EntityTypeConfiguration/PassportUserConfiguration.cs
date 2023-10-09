using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTest.Domain;

namespace ProjectTest.Persistence.EntityTypeConfiguration
{
    public class PassportUserConfiguration: IEntityTypeConfiguration<PassportUser>
    {
        public void Configure(EntityTypeBuilder<PassportUser> builder) 
        {
            builder.HasKey(passportUser =>  passportUser.Id);
            builder.HasIndex(passportUser =>  passportUser.Id).IsUnique();
            builder.Property(passportUser => passportUser.Gender).HasMaxLength(30).IsRequired();
            builder.Property(passportUser => passportUser.Nationality).HasMaxLength(100).IsRequired();
            builder.HasOne(passportUser => passportUser.User).WithOne(user => user.Passport)
                .HasForeignKey<PassportUser>(passportUser => passportUser.UserId).IsRequired();
            builder.HasIndex(passportUser => passportUser.UserId).IsUnique();

            builder.ToTable(nameof(PassportUser));
        }
    }
}

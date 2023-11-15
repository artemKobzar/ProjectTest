using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Persistence.EntityTypeConfiguration
{
    public class EventTypeConfiguration: IEntityTypeConfiguration<EventType>
    {
        public void Configure(EntityTypeBuilder<EventType> builder) 
        {
            //builder.HasMany<EventMessageResult>().WithOne().HasForeignKey(eventMessage => eventMessage.EventId).IsRequired();
            builder.HasKey(eventType => eventType.Id);
            builder.Property(eventType => eventType.Code).HasConversion(new EnumToStringConverter<CodeStatus>()).HasMaxLength(55).IsRequired();
            builder.Property(eventType => eventType.Description).HasMaxLength(155).IsRequired();

            builder.ToTable(nameof(EventType));
        }
    }
}

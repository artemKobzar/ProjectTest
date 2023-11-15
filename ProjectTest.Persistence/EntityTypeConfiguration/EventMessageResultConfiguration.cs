using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Persistence.EntityTypeConfiguration
{
    public class EventMessageResultConfiguration: IEntityTypeConfiguration<EventMessageResult>
    {
        public void Configure (EntityTypeBuilder<EventMessageResult> builder)
        {
            builder.HasKey(eventMessage => eventMessage.Id);
            builder.Property(eventMessage => eventMessage.Message).HasMaxLength(255).IsRequired();
            builder.Property(eventMessage => eventMessage.EventId).HasMaxLength(55).IsRequired().HasColumnName("EventId");
            builder.HasOne<EventType>().WithMany().HasForeignKey(eventType => eventType.EventId).IsRequired();

            builder.ToTable(nameof(EventMessageResult));
        }
    }
}

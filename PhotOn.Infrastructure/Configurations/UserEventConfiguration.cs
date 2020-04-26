using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotOn.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Infrastructure.Configurations
{
    public class UserEventConfiguration : IEntityTypeConfiguration<UserEvent>
    {
        public void Configure(EntityTypeBuilder<UserEvent> builder)
        {
            {
                builder.HasKey(t => new { t.EventId, t.UserId });

                builder.HasOne(sc => sc.User)
                    .WithMany(s => s.UserEvents)
                    .HasForeignKey(sc => sc.UserId);

                builder.HasOne(sc => sc.Event)
                    .WithMany(c => c.UserEvents)
                    .HasForeignKey(sc => sc.EventId)
                    .OnDelete(DeleteBehavior.Restrict);
            }

        }
    }
}

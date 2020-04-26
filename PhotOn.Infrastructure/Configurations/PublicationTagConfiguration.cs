using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotOn.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Infrastructure.Configurations
{
    public class PublicationTagConfiguration : IEntityTypeConfiguration<PublicationTag>
    {
        public void Configure(EntityTypeBuilder<PublicationTag> builder)
        {
            {
                builder.HasKey(t => new { t.PublicationId, t.TagId });

                builder.HasOne(sc => sc.Tag)
                    .WithMany(s => s.PublicationTags)
                    .HasForeignKey(sc => sc.TagId);

                builder.HasOne(sc => sc.Publication)
                    .WithMany(c => c.PublicationTags)
                    .HasForeignKey(sc => sc.PublicationId)
                    .OnDelete(DeleteBehavior.Restrict);
            }

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotOn.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Infrastructure.Configurations
{
    class SavedPublicationConfiguration : IEntityTypeConfiguration<SavedPublication>
    {
        public void Configure(EntityTypeBuilder<SavedPublication> builder)
        {
            {
                builder.HasKey(t => new { t.UserId, t.PublicationId });

                builder.HasOne(sc => sc.User)
                    .WithMany(s => s.SavedPublications)
                    .HasForeignKey(sc => sc.UserId);

                builder.HasOne(sc => sc.Publication)
                    .WithMany(c => c.SavedPublications)
                    .HasForeignKey(sc => sc.PublicationId)
                    .OnDelete(DeleteBehavior.Restrict);
            }

        }
    }
}

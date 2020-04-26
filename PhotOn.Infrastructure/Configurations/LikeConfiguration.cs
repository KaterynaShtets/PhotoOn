using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotOn.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Infrastructure.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            {
                builder.HasKey(t => new { t.PublicationId, t.UserId });

                builder.HasOne(sc => sc.User)
                    .WithMany(s => s.Likes)
                    .HasForeignKey(sc => sc.UserId);

                builder.HasOne(sc => sc.Publication)
                    .WithMany(c => c.Likes)
                    .HasForeignKey(sc => sc.PublicationId)
                    .OnDelete(DeleteBehavior.Restrict);
            }

        }
    }
}

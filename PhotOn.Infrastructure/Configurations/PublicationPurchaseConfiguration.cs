using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotOn.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Infrastructure.Configurations
{
    public class PublicationPurchaseConfiguration : IEntityTypeConfiguration<PublicationPurchase>
    {
        public void Configure(EntityTypeBuilder<PublicationPurchase> builder)
        {
            {
                builder.HasKey(t => new { t.UserId, t.PublicationId });

                builder.HasOne(sc => sc.User)
                    .WithMany(s => s.PublicationPurchases)
                    .HasForeignKey(sc => sc.UserId);

                builder.HasOne(sc => sc.Publication)
                    .WithMany(c => c.PublicationPurchases)
                    .HasForeignKey(sc => sc.PublicationId)
                    .OnDelete(DeleteBehavior.Restrict);
            }

        }
    }
}

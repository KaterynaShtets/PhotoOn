using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotOn.Core.Entities;

namespace PhotOn.Infrastructure.Configurations
{
    class PublicationImageConfiguration : IEntityTypeConfiguration<PublicationImage>
    {
        public void Configure(EntityTypeBuilder<PublicationImage> builder)
        {
            {
                builder.HasKey(t => new { t.PublicationId, t.ImageLink });

                builder.HasOne(sc => sc.Publication)
                    .WithMany(s => s.PublicationImagies)
                    .HasForeignKey(sc => sc.PublicationId);
            }
        }
    }
}

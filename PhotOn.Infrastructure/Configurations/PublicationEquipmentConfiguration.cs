using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotOn.Core.Entities;

namespace PhotOn.Infrastructure.Configurations
{
    public class PublicationEquipmentConfiguration : IEntityTypeConfiguration<PublicationEquipment>
    {
        public void Configure(EntityTypeBuilder<PublicationEquipment> builder)
        {
            {
                builder.HasKey(t => new { t.PublicationId, t.EquipmentId });

                builder.HasOne(sc => sc.Equipment)
                    .WithMany(s => s.PublicationEquipment)
                    .HasForeignKey(sc => sc.EquipmentId);

                builder.HasOne(sc => sc.Publication)
                    .WithMany(c => c.PublicationEquipments)
                    .HasForeignKey(sc => sc.PublicationId)
                    .OnDelete(DeleteBehavior.Restrict);
            }

        }
    }
}


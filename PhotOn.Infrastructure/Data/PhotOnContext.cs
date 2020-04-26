using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotOn.Core.Entities;
using System.Reflection;

namespace PhotOn.Infrastructure.Data
{
    public class PhotOnContext : IdentityDbContext
    {
        public DbSet<Like> Likes { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<PublicationTag> PublicationTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<PublicationEquipment> PublicationEquipments { get; set; }
        public DbSet<PublicationPurchase> PublicationPurchases { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<PublicationImage> PublicationImages { get; set; }
        public DbSet<SavedPublication> SavedPublications { get; set; }

        public PhotOnContext(DbContextOptions<PhotOnContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}

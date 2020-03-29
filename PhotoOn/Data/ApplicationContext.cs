using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoOn.Models;

namespace PhotoOn.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        public DbSet<Like> Likes { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<PublicationTag> PublicationTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserBuyPublication> UserBuyPublications { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}

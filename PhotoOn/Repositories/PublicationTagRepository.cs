using Microsoft.EntityFrameworkCore;
using PhotoOn.Data;
using PhotoOn.Interfaces;
using PhotoOn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoOn.Repositories
{
    public class PublicationTagRepository : IRepository<PublicationTag>
    {
        private readonly ApplicationContext db;

        public PublicationTagRepository(ApplicationContext context)
        {
            db = context;
        }
        public void Create(PublicationTag item)
        {
            db.PublicationTags.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var tag = db.PublicationTags.Where(t => t.Id.Equals(id)).FirstOrDefault();
            db.PublicationTags.Remove(tag);
            Save();
        }

        public IEnumerable<PublicationTag> GetAll()
        {
            var tags = db.PublicationTags.Include(u => u.Publication).Include(t=>t.Tag);
            return tags;
        }

        public PublicationTag GetOne(int id)
        {
            var tag = db.PublicationTags.Where(p => p.Id.Equals(id)).Include(u => u.Publication).Include(t=>t.Tag).FirstOrDefault();
            return tag;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(PublicationTag item)
        {
            db.PublicationTags.Update(item);
            Save();
        }
    }
}

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
    public class TagRepositorycs : IRepository<Tag>
    {
        private readonly ApplicationContext db;

        public TagRepositorycs(ApplicationContext context)
        {
            db = context;
        }
        public void Create(Tag item)
        {
            db.Tags.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var tag = db.Tags.Where(t => t.Id.Equals(id)).FirstOrDefault();
            db.Tags.Remove(tag);
            Save();
        }

        public IEnumerable<Tag> GetAll()
        {
            var tags = db.Tags.Include(u => u.Publications);
            return tags;
        }

        public Tag GetOne(int id)
        {
            var tag = db.Tags.Where(p => p.Id.Equals(id)).Include(u => u.Publications).FirstOrDefault();
            return tag;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Tag item)
        {
            db.Tags.Update(item);
            Save();
        }
    }
}

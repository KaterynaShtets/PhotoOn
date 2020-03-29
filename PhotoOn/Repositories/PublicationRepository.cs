using PhotoOn.Data;
using PhotoOn.Interfaces;
using PhotoOn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoOn.Repositories
{
    public class PublicationRepository : IRepository<Publication>
    {
        private readonly ApplicationContext db;

        public PublicationRepository(ApplicationContext context)
        {
            db = context;
        }
        public void Create(Publication item)
        {
            db.Publications.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var publication = db.Publications.Where(pub => pub.Id.Equals(id)).FirstOrDefault();
            db.Publications.Remove(publication);
            Save();
        }

        public IEnumerable<Publication> GetAll()
        {
            var publications = db.Publications;
            return publications;
        }

        public Publication GetOne(int id)
        {
            var publication = db.Publications.Where(p => p.Id.Equals(id)).FirstOrDefault();
            return publication;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Publication item)
        {
            db.Publications.Update(item);
            Save();
        }
    }
}

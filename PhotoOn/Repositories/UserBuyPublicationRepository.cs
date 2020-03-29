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
    public class UserBuyPublicationRepository : IRepository<UserBuyPublication>
    {
        private readonly ApplicationContext db;

        public UserBuyPublicationRepository(ApplicationContext context)
        {
            db = context;
        }
        public void Create(UserBuyPublication item)
        {
            db.UserBuyPublications.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var buy = db.UserBuyPublications.Where(t => t.Id.Equals(id)).FirstOrDefault();
            db.UserBuyPublications.Remove(buy);
            Save();
        }

        public IEnumerable<UserBuyPublication> GetAll()
        {
            var tags = db.UserBuyPublications.Include(u => u.User).Include(t=>t.Publication);
            return tags;
        }

        public UserBuyPublication GetOne(int id)
        {
            var buy = db.UserBuyPublications.Where(p => p.Id.Equals(id)).Include(u => u.User).Include(p=>p.Publication).FirstOrDefault();
            return buy;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(UserBuyPublication item)
        {
            db.UserBuyPublications.Update(item);
            Save();
        }
    }
}

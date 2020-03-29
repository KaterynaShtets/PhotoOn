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
    public class LikeRepository : IRepository<Like>
    {
        private readonly ApplicationContext db;

        public LikeRepository(ApplicationContext context)
        {
            db = context;
        }
        public void Create(Like item)
        {
            db.Likes.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var like = db.Likes.Where(pub => pub.Id.Equals(id)).FirstOrDefault();
            db.Likes.Remove(like);
            Save();
        }

        public IEnumerable<Like> GetAll()
        {
            var likes = db.Likes.Include(u=>u.User).Include(p=>p.Publication);
            return likes;
        }

        public Like GetOne(int id)
        {
            var like = db.Likes.Where(p => p.Id.Equals(id)).Include(u => u.User).Include(p => p.Publication).FirstOrDefault();
            return like;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Like item)
        {
            db.Likes.Update(item);
            Save();
        }
    }
}

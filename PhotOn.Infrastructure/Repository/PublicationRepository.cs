using Microsoft.EntityFrameworkCore;
using PhotOn.Core.Entities;
using PhotOn.Core.Repositories;
using PhotOn.Infrastructure.Data;
using PhotOn.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PhotOn.Infrastructure.Repository
{
    public class PublicationRepository : EditRepository<Publication>, IPublicationRepository
    {
        private readonly PhotOnContext _db;
      
        public PublicationRepository(PhotOnContext db) :
            base (db)
        {
            _db = db;
        }

        public Publication Get(int id)
        {
            return _db.Publications
                      .Include(c => c.User)
                       .Include(c => c.PublicationEquipments.Select(p => p.Equipment))
                       .Include(c => c.PublicationImagies)
                       .Include(c => c.PublicationPurchases.Select(p => p.User))
                       .Include(c => c.PublicationTags.Select(p => p.Tag))
                       .SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Publication> GetAll()
        {
            return _db.Publications
                        .Include(c => c.User)
                        .Include(c => c.PublicationEquipments.Select(p => p.Equipment))
                        .Include(c => c.PublicationImagies)
                        .Include(c => c.PublicationPurchases.Select(p => p.User))
                        .Include(c => c.PublicationTags.Select(p => p.Tag));
        }

        public IEnumerable<Publication> Find(Expression<Func<Publication, bool>> predicate)
        {
            return _db.Publications
                        .Where(predicate)
                        .Include(c => c.User)
                        .Include(c => c.PublicationEquipments.Select(p => p.Equipment))
                        .Include(c => c.PublicationImagies)
                        .Include(c => c.PublicationPurchases.Select(p => p.User))
                        .Include(c => c.PublicationTags.Select(p => p.Tag));
        }

        public Publication SingleOrDefault(Expression<Func<Publication, bool>> predicate)
        {
            return _db.Publications
                        .Include(c => c.User)
                       .Include(c => c.PublicationEquipments.Select(p => p.Equipment))
                       .Include(c => c.PublicationImagies)
                       .Include(c => c.PublicationPurchases.Select(p => p.User))
                       .Include(c => c.PublicationTags.Select(p => p.Tag))
                       .SingleOrDefault(predicate);
        }
    }
}

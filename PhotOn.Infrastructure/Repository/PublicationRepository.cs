using Microsoft.EntityFrameworkCore;
using PhotOn.Core.Entities;
using PhotOn.Core.Entities.Base;
using PhotOn.Core.Repositories;
using PhotOn.Infrastructure.Data;
using PhotOn.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Infrastructure.Repository
{
    public class PublicationRepository : EditRepository<Publication>, IPublicationRepository
    {
        internal DbSet<Publication> _dbSet;
        public PublicationRepository(PhotOnContext _dbContext): base(_dbContext)
        {
            this._dbSet = _dbContext.Set<Publication>();
        }

        public IEnumerable<Publication> Find(Expression<Func<Publication, bool>> predicate)
        {
            return _dbSet
                        .Where(predicate)
                        .Include(p => p.User)
                        .Include(p => p.PublicationEquipments)
                        .Include(p => p.PublicationPurchases)
                        .Include(p=>p.PublicationTags)
                        .Include(p=>p.SavedPublications);
        }

        public Publication Get(int id)
        {
            return _dbSet.Include(p => p.User)
                        .Include(p => p.PublicationEquipments)
                        .Include(p => p.PublicationPurchases)
                        .Include(p => p.PublicationTags)
                        .Include(p => p.SavedPublications)
                        .SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Publication> GetAll()
        {
            return _dbSet.Include(p => p.User)
                        .Include(p => p.PublicationEquipments).ThenInclude(p => p.Equipment)
                        .Include(p => p.PublicationPurchases)
                        .Include(p => p.PublicationTags).ThenInclude(p=>p.Tag)
                        .Include(p => p.SavedPublications);
        }

        public IEnumerable<Publication> GetAllPresent()
        {
            return _dbSet.Include(p => p.User)
                        .Include(p => p.PublicationEquipments).ThenInclude(p => p.Equipment)
                        .Include(p => p.PublicationPurchases)
                        .Include(p => p.PublicationTags).ThenInclude(p => p.Tag)
                        .Include(p => p.SavedPublications)
                        .Where(p=>p.IsDeleted == false);
        }


        public Publication SingleOrDefault(Expression<Func<Publication, bool>> predicate)
        {
            return _dbSet.Include(p => p.User)
                        .Include(p => p.PublicationEquipments)
                        .Include(p => p.PublicationPurchases)
                        .Include(p => p.PublicationTags)
                        .Include(p => p.SavedPublications)
                        .SingleOrDefault(predicate);
        }
    }
}

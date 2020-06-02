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
        internal PhotOnContext _dbContext;
        public PublicationRepository(PhotOnContext dbContext): base(dbContext)
        {
            this._dbSet = dbContext.Set<Publication>();
            _dbContext = dbContext;
        }

        public void AddLikeToPublication(string userId, int publicationId) 
        {
            var like = new Like()
            {
                UserId = userId,
                PublicationId = publicationId
            };

            if (_dbContext.Likes
                .Any(l => l.PublicationId == publicationId && l.UserId == userId))
            {
                _dbContext.Likes.Remove(like);
            }
            else 
            {
                _dbContext.Likes.Add(like);
            }
        }

        public void SavePublication(string userId, int publicationId)
        {
            var saved = new SavedPublication()
            {
                UserId = userId,
                PublicationId = publicationId
            };

            _dbContext.SavedPublications.Add(saved);
        }

        public void AddTagToPublication(int tagId, int publicationId) 
        {
            var tagToPunlication = new PublicationTag()
            {
                TagId = tagId,
                PublicationId = publicationId
            };

            _dbContext.PublicationTags.Add(tagToPunlication);
        }

        public void AddEquipmentToPublication(int equipmentId, int publicationId) 
        {
            var equipmentToPublication = new PublicationEquipment()
            {
                EquipmentId = equipmentId,
                PublicationId = publicationId
            };

            _dbContext.PublicationEquipments.Add(equipmentToPublication);
        }

        public void BuyPublication(string userId, int publicationId)
        {
            var purchase = new PublicationPurchase()
            {
                UserId = userId,
                PublicationId = publicationId
            };

            _dbContext.PublicationPurchases.Add(purchase);
        }

        public bool isPurchased(string userId, int publicationId) 
        {
            var purchase = new PublicationPurchase()
            {
                UserId = userId,
                PublicationId = publicationId
            };
            if (_dbContext.PublicationPurchases
                .Any(pp => pp.PublicationId == publicationId && pp.UserId == userId))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public void ApprovePublication(int publicationId) 
        {
            _dbSet.SingleOrDefault(p => p.Id == publicationId).IsApproved = true;
        }

        public void RejectPublication(int publicationId)
        {
            _dbSet.SingleOrDefault(p => p.Id == publicationId).IsApproved = false;
        }

        public IEnumerable<Publication> Find(Expression<Func<Publication, bool>> predicate)
        {
            return _dbSet
                        .Where(predicate)
                        .Include(p => p.User)
                        .Include(p => p.PublicationEquipments).ThenInclude(pt => pt.Equipment)
                        .Include(p => p.PublicationPurchases)
                        .Include(p=>p.PublicationTags).ThenInclude(pt => pt.Tag)
                        .Include(p=>p.SavedPublications);
        }

        public Publication Get(int id)
        {
            return _dbSet.Include(p => p.User)
                        .Include(p => p.PublicationEquipments).ThenInclude(pt => pt.Equipment)
                        .Include(p => p.PublicationPurchases)
                        .Include(p => p.PublicationTags).ThenInclude(pt => pt.Tag)
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

        public IEnumerable<Publication> GetAllPresentApproved()
        {
            return _dbSet.Include(p => p.User)
                        .Include(p => p.PublicationEquipments).ThenInclude(p => p.Equipment)
                        .Include(p => p.PublicationPurchases)
                        .Include(p => p.PublicationTags).ThenInclude(p => p.Tag)
                        .Include(p => p.SavedPublications)
                        .Where(p => p.IsDeleted == false && p.IsApproved == true);
        }

        public IEnumerable<Publication> GetAllPresentDisApproved()
        {
            return _dbSet.Include(p => p.User)
                        .Include(p => p.PublicationEquipments).ThenInclude(p => p.Equipment)
                        .Include(p => p.PublicationPurchases)
                        .Include(p => p.PublicationTags).ThenInclude(p => p.Tag)
                        .Include(p => p.SavedPublications)
                        .Where(p => p.IsDeleted == false && p.IsApproved == false);
        }

        public int GetPublicationLikes(int publicationId) 
        {
            return _dbContext.Likes.Where(l => l.PublicationId == publicationId).Count();
        }
        public Publication SingleOrDefault(Expression<Func<Publication, bool>> predicate)
        {
            return _dbSet.Include(p => p.User)
                        .Include(p => p.PublicationEquipments).ThenInclude(pt => pt.Equipment)
                        .Include(p => p.PublicationPurchases)
                        .Include(p => p.PublicationTags).ThenInclude(pt => pt.Tag)
                        .Include(p => p.SavedPublications)
                        .SingleOrDefault(predicate);
        }
    }
}

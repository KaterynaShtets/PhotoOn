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
    public class EquipmentRepository : EditRepository<Equipment>, IEquipmentRepository
    {
        internal DbSet<Equipment> _dbSet;
        public EquipmentRepository(PhotOnContext _dbContext) : base(_dbContext)
        {
            this._dbSet = _dbContext.Set<Equipment>();
        }
        public IEnumerable<Equipment> Find(Expression<Func<Equipment, bool>> predicate)
        {
            return _dbSet
                .Where(predicate);
        }

        public Equipment Get(int id)
        {
            return _dbSet
                 .SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _dbSet;
        }
    }
}

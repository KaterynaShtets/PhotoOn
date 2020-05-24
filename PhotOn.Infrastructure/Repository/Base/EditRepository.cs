using Microsoft.EntityFrameworkCore;
using PhotOn.Core.Entities.Base;
using PhotOn.Core.Repositories.Base;
using PhotOn.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Infrastructure.Repository.Base
{
    public class EditRepository<T> : IEditRepository<T> where T : Entity
    {
        protected readonly PhotOnContext _dbContext;
        internal DbSet<T> _dbSet;

        public EditRepository(PhotOnContext dbContext)
        {
            _dbContext = dbContext;
            this._dbSet = _dbContext.Set<T>();
        }
       

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T entity = _dbSet.Find(id);
            entity.IsDeleted = true;
        }
    }

}

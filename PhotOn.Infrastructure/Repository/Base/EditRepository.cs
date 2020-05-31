using Microsoft.EntityFrameworkCore;
using PhotOn.Core.Entities.Base;
using PhotOn.Core.Repositories.Base;
using PhotOn.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Infrastructure.Repository.Base
{
    public class EditRepository<TEntity> : IEditRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly PhotOnContext Context;

        public EditRepository(PhotOnContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void SoftDelete(int id)
        {
            Context.Set<TEntity>().Find(id).IsDeleted = true;
        }

        public void RemoveSoftDelete(int id)
        {
            Context.Set<TEntity>().Find(id).IsDeleted = false;
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}

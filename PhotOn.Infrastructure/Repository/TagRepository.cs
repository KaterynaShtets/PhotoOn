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
    public class TagRepository : EditRepository<Tag>, ITagRepository
    {
        internal DbSet<Tag> _dbSet;
        public TagRepository(PhotOnContext _dbContext) : base(_dbContext)
        {
            this._dbSet = _dbContext.Set<Tag>();
        }

        
        public IEnumerable<Tag> Find(Expression<Func<Tag, bool>> predicate)
        {
            return _dbSet
                .Where(predicate);
        }

        public Tag Get(int id)
        {
            return _dbSet
               .SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _dbSet;
        }
    }
}

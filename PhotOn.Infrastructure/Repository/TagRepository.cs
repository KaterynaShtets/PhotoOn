using PhotOn.Core.Entities;
using PhotOn.Core.Repositories;
using PhotOn.Core.Repositories.Base;
using PhotOn.Infrastructure.Data;
using PhotOn.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PhotOn.Infrastructure.Repository
{
    public class TagRepository : EditRepository<Tag>, ITagRepository
    {
        private readonly PhotOnContext _db;

        public TagRepository(PhotOnContext db) :
            base(db)
        {
            _db = db;
        }

        public IEnumerable<Tag> Find(Expression<Func<Tag, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Tag SingleOrDefault(Expression<Func<Tag, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Tag IReadRepository<Tag>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Tag> IReadRepository<Tag>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

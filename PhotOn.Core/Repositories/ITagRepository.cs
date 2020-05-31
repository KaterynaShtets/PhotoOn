using PhotOn.Core.Entities;
using PhotOn.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PhotOn.Core.Repositories
{
    public interface ITagRepository : IEditRepository<Tag>, IReadRepository<Tag>
    {
        IEnumerable<Tag> Find(Expression<Func<Tag, bool>> predicate);
    }
}

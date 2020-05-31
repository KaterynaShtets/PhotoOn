using PhotOn.Core.Entities;
using PhotOn.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PhotOn.Core.Repositories
{
    public interface IEquipmentRepository : IEditRepository<Equipment>, IReadRepository<Equipment>
    {
        IEnumerable<Equipment> Find(Expression<Func<Equipment, bool>> predicate);
    }
}

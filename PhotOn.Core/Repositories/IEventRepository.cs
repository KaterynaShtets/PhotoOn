using PhotOn.Core.Entities;
using PhotOn.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PhotOn.Core.Repositories
{
    public interface IEventRepository : IEditRepository<Event>, IReadRepository<Event>
    {
        IEnumerable<Event> Find(Expression<Func<Event, bool>> predicate);
        void AccomplishEvent(string userId, int eventId);
        Tag GetEventTag(int eventId);
    }
}

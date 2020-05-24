using PhotOn.Core.Entities;
using PhotOn.Core.Repositories;
using PhotOn.Infrastructure.Data;
using PhotOn.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PhotOn.Infrastructure.Repository
{
    public class EventRepository : EditRepository<Event>, IEventRepository
    {
        private readonly PhotOnContext _db;

        public EventRepository(PhotOnContext db) :
            base(db)
        {
            _db = db;
        }

        public IEnumerable<Event> Find(Expression<Func<Event, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Event Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public Event SingleOrDefault(Expression<Func<Event, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

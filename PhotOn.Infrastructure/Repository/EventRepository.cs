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
    public class EventRepository : EditRepository<Event>, IEventRepository
    {
        internal DbSet<Event> _dbSet;
        internal PhotOnContext _dbContext;
        public EventRepository(PhotOnContext dbContext) : base(dbContext)
        {
            this._dbSet = dbContext.Set<Event>();
            _dbContext = dbContext;
        }

        public void AccomplishEvent(string userId, int eventId)
        {
            var userEvent = new UserEvent
            {
                UserId = userId,
                EventId = eventId
            };

            _dbContext.UserEvents.Add(userEvent);
        }

        public IEnumerable<Event> Find(Expression<Func<Event, bool>> predicate)
        {
            return _dbSet
                .Where(predicate);
        }

        public Event Get(int eventId)
        {
           return _dbSet
                .Include(p => p.Tag)
                .SingleOrDefault(e => e.Id == eventId);
        }

        public IEnumerable<Event> GetAll()
        {
            return _dbSet
                 .Include(e => e.Tag)
                 .Where(e => e.IsDeleted == false);
        }

        public Tag GetEventTag(int eventId)
        {
            return _dbSet
                .Include(p => p.Tag)
                .SingleOrDefault(e => e.Id == eventId).Tag;
        }
    }
}

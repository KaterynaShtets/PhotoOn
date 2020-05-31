﻿using PhotOn.Core.Entities;
using PhotOn.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Core.Repositories
{
    public interface IPublicationRepository : IEditRepository<Publication>, IReadRepository<Publication>
    {
        void AddLikeToPublication(string userId, int publicationId);
        void SavePublication(string userId, int publicationId);
        IEnumerable<Publication> GetAllPresent();
        IEnumerable<Publication> Find(Expression<Func<Publication, bool>> predicate);
        Publication SingleOrDefault(Expression<Func<Publication, bool>> predicate);
    }
}

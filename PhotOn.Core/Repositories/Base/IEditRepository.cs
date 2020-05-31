using PhotOn.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Core.Repositories.Base
{
    public interface IEditRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void SoftDelete(int id);
        void RemoveSoftDelete(int id);
        void Update(TEntity entity);
    }
}

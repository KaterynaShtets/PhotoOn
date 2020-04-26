using System.Collections.Generic;

namespace PhotoOn.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetOne(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}

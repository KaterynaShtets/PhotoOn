using PhotOn.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Infrastructure.InterfacesDelete
{
    public interface IEditRepository <T> where T : Entity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}

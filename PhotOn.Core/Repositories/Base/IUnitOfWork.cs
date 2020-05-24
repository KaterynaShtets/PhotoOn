using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Core.Repositories
{
    public interface IUnitOfWork 
    {
        public void Save();
    }
}

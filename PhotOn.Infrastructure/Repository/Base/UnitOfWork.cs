using PhotOn.Core.Repositories;
using PhotOn.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Infrastructure.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhotOnContext _db;

        public UnitOfWork(PhotOnContext db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}

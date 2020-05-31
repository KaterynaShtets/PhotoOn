using PhotOn.Core.Entities.Base;
using PhotOn.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Core.Repositories
{
    public interface IUnitOfWork
    {
        IPublicationRepository Publications { get; }
        ITagRepository Tags { get; }
        IEquipmentRepository Equipments{ get; }
       
        public void Save();
    }
}

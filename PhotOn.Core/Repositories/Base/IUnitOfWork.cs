using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Core.Repositories
{
    public interface IUnitOfWork 
    {
        IPublicationRepository PublicatonRepository { get; }
        ITagRepository TagRepository { get; }
        IEquipmentRepository EquipmentRepository { get; }
        public void Save();
    }
}

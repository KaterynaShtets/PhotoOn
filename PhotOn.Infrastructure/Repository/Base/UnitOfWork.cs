using PhotOn.Core.Entities.Base;
using PhotOn.Core.Repositories;
using PhotOn.Core.Repositories.Base;
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
        private IPublicationRepository _publicatonRepository;
        private IEventRepository _eventRepository;
        private ITagRepository _tagRepository;
        private IEquipmentRepository _equipmentRepository;

        public UnitOfWork(PhotOnContext db)
        {
            _db = db;
        }

        public IPublicationRepository Publications
        {
            get 
            { 
                return _publicatonRepository = _publicatonRepository ?? 
                    new PublicationRepository(_db); 
            }
        }

        public ITagRepository Tags
        { 
            get 
            { 
                return _tagRepository = _tagRepository ?? 
                    new TagRepository(_db); 
            }

        }

        public IEquipmentRepository Equipments
        {
            get 
            {
                return _equipmentRepository = _equipmentRepository ?? 
                    new EquipmentRepository(_db); 
            }

        }

        public IEventRepository Events
        {
            get 
            { 
                return _eventRepository = _eventRepository ?? 
                    new EventRepository(_db); 
            }

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

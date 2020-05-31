using PhotOn.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Interfaces
{
    public interface IEquipmentService
    {
        EquipmentDto GetEquipment(int id);
        IEnumerable<EquipmentDto> GetAllEquipment();
        void AddEquipment(EquipmentDto tagDto);
        void EditEquipment(EquipmentDto tagDto);
        void SoftDeleteEquipment(int id);
    }
}

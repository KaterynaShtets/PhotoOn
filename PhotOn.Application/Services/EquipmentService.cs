using AutoMapper;
using Microsoft.Extensions.Logging;
using PhotOn.Application.Dtos;
using PhotOn.Application.Interfaces;
using PhotOn.Application.Mapper;
using PhotOn.Core.Entities;
using PhotOn.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IUnitOfWork _db;
        private readonly ILogger<EquipmentService> _logger;

        public EquipmentService(IUnitOfWork unitOfWork, ILogger<EquipmentService> logger)
        {
            _db = unitOfWork;
            _logger = logger;
        }

        public void AddEquipment(EquipmentDto equipmentDto)
        {

            try
            {
                var equipment = ObjectMapper.Mapper.Map<Equipment>(equipmentDto);
                _db.Equipments.Add(equipment);
                _db.Save();
            }
            catch
            {
                _logger.LogWarning("AddEquipment failed");
            }
        }

        public void EditEquipment(EquipmentDto equipmentDto)
        {
            try
            {
                var equipment = ObjectMapper.Mapper.Map<Equipment>(equipmentDto);
                _db.Equipments.Update(equipment);
                _db.Save();
            }
            catch
            {
                _logger.LogWarning("EditEquipment failed");
            }
        }

        public IEnumerable<EquipmentDto> GetAllEquipment()
        {
           var equipments = _db.Equipments.GetAll();
            return ObjectMapper.Mapper.Map<IEnumerable<EquipmentDto>>(equipments);
        }

        public EquipmentDto GetEquipment(int id)
        {
            var equipment = _db.Equipments.Get(id);
            return ObjectMapper.Mapper.Map<EquipmentDto>(equipment);
        }

        public void SoftDeleteEquipment(int id)
        {
            _db.Equipments.SoftDelete(id);
        }
    }
}

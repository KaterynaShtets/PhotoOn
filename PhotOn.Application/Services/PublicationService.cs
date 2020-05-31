using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PhotOn.Application.Dtos;
using PhotOn.Application.Interfaces;
using PhotOn.Application.Mapper;
using PhotOn.Application.Models;
using PhotOn.Core.Entities;
using PhotOn.Core.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;

namespace PhotOn.Application.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IUnitOfWork _db;
        private readonly ILogger<PublicationService> _logger;
        private readonly IFileStorageServcie _fileStorageService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly string containerName = "publications";

        public PublicationService(IUnitOfWork unitOfWork, ILogger<PublicationService> logger, IFileStorageServcie fileStorageServcie, IHttpContextAccessor httpContextAccessor)
        {
            _db = unitOfWork;
            _logger = logger;
            _fileStorageService = fileStorageServcie;
            _httpContextAccessor = httpContextAccessor;
        }

        public  void Add(PublicationCreationDto publicationCreationModel)
        {
            try
            {
                var publication = ObjectMapper.Mapper.Map<Publication>(publicationCreationModel);
                if (publication == null)
                    throw new ApplicationException($"Entity could not be mapped.");
                if (publicationCreationModel.ImageFile != null) 
                {
                    using (var memoryStream = new MemoryStream()) 
                    {
                         publicationCreationModel.ImageFile.CopyToAsync(memoryStream);
                        var content = memoryStream.ToArray();
                        var extension = Path.GetExtension(publicationCreationModel.ImageFile.FileName);
                        publication.ImageLink =  _fileStorageService.SaveFile(content, extension, containerName, publicationCreationModel.ImageFile.ContentType);
                        
                    }
                }
                _db.Publications.Add(publication);
                _db.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError("Api failure in Add call", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _db.Publications.SoftDelete(id);
                _db.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError("Api failure in Delete call", ex);
            }
        }

        public void Edit(int id, PublicationCreationDto publicationCreationModel)
        {
            try
            {
                var entity = _db.Publications.SingleOrDefault(x => x.Id == id);
                if (entity == null)
                    throw new ApplicationException($"Entity could not be mapped.");
                entity = ObjectMapper.Mapper.Map(publicationCreationModel, entity);
                if (publicationCreationModel.ImageFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        publicationCreationModel.ImageFile.CopyTo(memoryStream);
                        var content = memoryStream.ToArray();
                        var extension = Path.GetExtension(publicationCreationModel.ImageFile.FileName);
                        entity.ImageLink = _fileStorageService.EditFile(content, extension, containerName, entity.ImageLink, publicationCreationModel.ImageFile.ContentType);
                    }
                }

                _db.Publications.Update(entity);
                _db.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError("Api failure in Add call", ex);
            }
        }

        public PublicationDetailsDto Get(int id)
        {
            var publication = _db.Publications.Get(id);
            var mapped = ObjectMapper.Mapper.Map<PublicationDetailsDto>(publication);
            return mapped;
        }

        public IEnumerable<PublicationDetailsDto> GetAllPublications()
        {
            var publicationList = _db.Publications.GetAll();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<PublicationDetailsDto>>(publicationList);
            return mapped;
        }

        public IEnumerable<PublicationDetailsDto> FilterPublications(PublicationFilterModel filterPublicationModel)
        {
            var publicationsQueryable = _db.Publications.GetAll().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterPublicationModel.Title)) 
            {
                publicationsQueryable = publicationsQueryable.Where(p => p.Title.Contains(filterPublicationModel.Title));
            }

            if (filterPublicationModel.TagId.HasValue)
            {
                publicationsQueryable = publicationsQueryable
                    .Where(p => p.PublicationTags
                    .Any(pt => pt.TagId == filterPublicationModel.TagId));
            }

            if (filterPublicationModel.EquipmentId.HasValue)
            {
                publicationsQueryable = publicationsQueryable
                    .Where(p => p.PublicationEquipments
                    .Any(pt => pt.EquipmentId == filterPublicationModel.EquipmentId));
            }

            if (filterPublicationModel.isToday)
            {
                var today = DateTime.Today.Date;
                publicationsQueryable = publicationsQueryable.Where(p => p.PublicationDate.Date == today);
            }

            if (!string.IsNullOrWhiteSpace(filterPublicationModel.OrderingField))
            {
                try
                {
                    publicationsQueryable = publicationsQueryable
                        .OrderBy($"{filterPublicationModel.OrderingField}{(filterPublicationModel.AscendingOrder ? "ascending" : "descending")}");
                }
                catch 
                {
                    _logger.LogWarning("Could not order by filed:" + filterPublicationModel.OrderingField);
                }
            } 
            return ObjectMapper.Mapper.Map<IEnumerable<PublicationDetailsDto>>(publicationsQueryable.ToList());
        }

        public IEnumerable<PublicationDetailsDto> GetUserLikedPublications(string userId) 
        {
            var likedPublications =  _db.Publications.GetAllPresent().Where(p => p.Likes.Select(l => l.UserId).Contains(userId));
            return ObjectMapper.Mapper.Map<IEnumerable<PublicationDetailsDto>>(likedPublications);
        }

        public IEnumerable<PublicationDetailsDto> GetUserSavedPublications(string userId)
        {
            var likedPublications = _db.Publications.GetAllPresent().Where(p => p.SavedPublications.Select(l => l.UserId).Contains(userId));
            return ObjectMapper.Mapper.Map<IEnumerable<PublicationDetailsDto>>(likedPublications);
        }

        public IEnumerable<PublicationDetailsDto> GetUserPublications(string userId)
        {
            var likedPublications = _db.Publications.GetAllPresent().Where(p => p.UserId == userId);
            return ObjectMapper.Mapper.Map<IEnumerable<PublicationDetailsDto>>(likedPublications);
        }

        public void LikePublication(int id)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            _db.Publications.AddLikeToPublication(userId, id);
        }

        public void SavePublication(int id)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            _db.Publications.SavePublication(userId, id);
        }
    }
}

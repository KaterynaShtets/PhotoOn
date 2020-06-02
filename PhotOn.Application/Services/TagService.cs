using Microsoft.Extensions.Logging;
using PhotOn.Application.Dtos;
using PhotOn.Application.Interfaces;
using PhotOn.Application.Mapper;
using PhotOn.Core.Entities;
using PhotOn.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotOn.Application.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _db;
        private readonly ILogger<TagService> _logger;

        public TagService(IUnitOfWork unitOfWork, ILogger<TagService> logger)
        {
            _db = unitOfWork;
            _logger = logger;
        }

        public void AddTag(TagDto tagDto)
        {
            try
            {
                var tag = ObjectMapper.Mapper.Map<Tag>(tagDto);
                var tags = _db.Tags.GetAll();
                if (!tags.Any(t=>t.Title == tag.Title))
                {
                    _db.Tags.Add(tag);
                }
                _db.Save();
            }
            catch
            {
                _logger.LogWarning("AddTag failed");
            }
        }

        public void EditTag(TagDto tagDto)
        {
            try
            {
                var tag = ObjectMapper.Mapper.Map<Tag>(tagDto);
                _db.Tags.Update(tag);
                _db.Save();
            }
            catch
            {
                _logger.LogWarning("EditTag failed");
            }
        }

        public IEnumerable<TagDto> GetAllTags()
        {
            var tags = _db.Tags.GetAll();
            return ObjectMapper.Mapper.Map<IEnumerable<TagDto>>(tags);
        }

        public TagDto GetTag(int id)
        {
            var tag = _db.Tags.Get(id);
            return ObjectMapper.Mapper.Map<TagDto>(tag);
        }

        public void SoftDeleteTag(int id)
        {
            _db.Tags.SoftDelete(id);
        }
    }
}

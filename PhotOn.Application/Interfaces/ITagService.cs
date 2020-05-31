using PhotOn.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Interfaces
{
    public interface ITagService
    {
        TagDto GetTag(int id);
        IEnumerable<TagDto> GetAllTags();
        void AddTag(TagDto tagDto);
        void EditTag(TagDto tagDto);
        void SoftDeleteTag(int id);
    }
}

using Microsoft.AspNetCore.Http;
using PhotOn.Application.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Dtos
{
    public class PublicationCreationDto 
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public string Title { get; set; }
        public int  Price { get; set; }
        public decimal coordX { get; set; }
        public decimal coordY { get; set; }
        public DateTime PublicationDate { get; set; }
        public TimeOfTheYearDto Season { get; set; }
        public string TextDescription { get; set; }
        public int LikeCount { get; set; }
        //[FileSIzeValidation(4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile ImageFile { get; set; }

        public List<TagDto> TagsDtos { get; set; }
        public List<EquipmentDto> EquipmentDtos { get; set; }
    }
}

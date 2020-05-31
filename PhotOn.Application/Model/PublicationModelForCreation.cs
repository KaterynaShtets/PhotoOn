using Microsoft.AspNetCore.Http;
using PhotOn.Application.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Models
{
    public class PublicationModelForCreation : PublicationModel
    {
        //[FileSIzeValidation(4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile ImageFile { get; set; }
    }
}

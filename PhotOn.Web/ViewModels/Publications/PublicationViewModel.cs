using Microsoft.AspNetCore.Http;
using PhotOn.Application.Dtos;
using PhotOn.Application.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhotOn.Web.ViewModels.Publications
{
    public class PublicationViewModel
    {
        public PublicationViewModel()
        {
            Id = 0;
        }

        public int Id { get; set; }

        public UserDto User { get; set; }

        [Display(Name = "Publication Name")]
        [Required(ErrorMessage = "Please, enter the publication name")]
        public string Title { get; set; }

        [Display(Name = "Price")]
        //[Required(ErrorMessage = "Please, enter the price")]
        [Range(0, 999999999)]
        public decimal? Price { get; set; }

        [Display(Name = "Coordinate X")]
        //[Required(ErrorMessage = "Please, enter the X")]
        public decimal coordX { get; set; }

        [Display(Name = "Coordinate Y")]
        //[Required(ErrorMessage = "Please, enter the Y")]
        public decimal coordY { get; set; }

        [Display(Name = "Season")]
        //[Required(ErrorMessage = "Please, select the season")]
        public TimeOfTheYearDto Season { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please, enter the description")]
        public string TextDescription { get; set; }


        public int LikeCount { get; set; }

        [FileSIzeValidation(4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile Picture { get; set; }

        public string ImageLink;

        public IEnumerable<EquipmentDto> EquipmentModels { get; private set; }
        public IEnumerable<TagDto> TagModels { get; private set; }

        public string PageTitle
        {
            get
            {
                return (Id == 0) ? "New publication" : "Editing publication";
            }
        }

        public bool IsNewCreated
        {
            get
            {
                return (Id == 0);
            }
        }
    }
}
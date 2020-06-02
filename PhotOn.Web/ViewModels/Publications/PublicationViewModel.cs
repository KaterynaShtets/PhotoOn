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
        [Required(ErrorMessage = "Please, enter the price, if your publication is free, put 0")]
        [Range(0, 999999999)]
        public int Price { get; set; }

        public decimal coordX { get; set; }
        public decimal coordY { get; set; }

        [Display(Name = "Season")]
        [Required(ErrorMessage = "Please, select the season")]
        public TimeOfTheYearDto Season { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please, enter the description")]
        public string TextDescription { get; set; }


        public int LikeCount { get; set; }

        [FileSIzeValidation(4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile Picture { get; set; }

        public string ImageLink;
        public bool IsApproved { get; set; }
        public List<EquipmentDto> EquipmentModels { get;  set; }
        public List<TagDto> TagModels { get; set; }

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
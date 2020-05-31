using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Models
{
    public enum TimeOfTheYearDto
    {
        None,
        Winter,
        Spring,
        Summer,
        Autumn
    }

    public class PublicationModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public decimal coordX { get; set; }
        public decimal coordY { get; set; }
        public DateTime PublicationDate { get; set; }
        public TimeOfTheYearDto Season { get; set; }
        public string TextDescription { get; set; }
        public int LikeCount { get; set; }

        public string ImageLink;
    }
}

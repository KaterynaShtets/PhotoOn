﻿using PhotOn.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace PhotOn.Core.Entities
{
    public class Event : Entity
    {
        public Event()
        {
            UserEvents = new List<UserEvent>();
        }

        public DateTime DateTime { get; set; }
        public string TextDescription { get; set; }
        public int AwardId { get; set; }
        public Award Award { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; }

    }
}
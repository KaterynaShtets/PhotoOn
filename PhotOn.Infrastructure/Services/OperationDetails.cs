﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Infrastructure.Services
{
    public class OperationDetails
    {
        public OperationDetails(bool succedeed, string message, string prop)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
        }

        public bool Succedeed { get; private set; }

        public string Message { get; private set; }

        public string Property { get; private set; }
    }
}

﻿using PhotOn.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Application.Interfaces
{
    public interface IUtilService
    {
        void DebitFromAccout(int sum);
        public void ReplenishBalance(int sum);
    }
}

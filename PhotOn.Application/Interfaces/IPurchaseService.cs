using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Interfaces
{
    public interface IPurchaseService
    {
        public void ReplenishBalance(decimal sum);
        public void DebitFromAccout(decimal sum);

    }
}

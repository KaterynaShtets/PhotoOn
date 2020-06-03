using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotOn.Web.ViewModels.Payment
{
    public class ReplenishBalanceViewModel
    {
        public ReplenishBalanceViewModel(int balance)
        {
            Balance = balance;
        }

        public int Balance { get; set; }
    }
}

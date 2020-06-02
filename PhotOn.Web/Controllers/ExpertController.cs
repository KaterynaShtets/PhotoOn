using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PhotOn.Web.Controllers
{
    public class ExpertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
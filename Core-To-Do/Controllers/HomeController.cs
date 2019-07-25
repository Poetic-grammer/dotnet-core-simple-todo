using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core_To_Do.Models;
using Core_To_Do.Services;

namespace Core_To_Do.Controllers
{
    public class HomeController : Controller
    {

        private IToDoDataService dataService;

        public HomeController(IToDoDataService dataService)
        {
            this.dataService = dataService;
        }

        public IActionResult Index()
        {
            return View(dataService.ListToDos());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

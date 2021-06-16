using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Homework3.Models;
using Homework3.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Homework3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;
        private readonly ICityService _cityService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService, ICityService cityService)
        {
            _logger = logger;
            _homeService = homeService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            //Console.WriteLine($"{_homeService.List()}");
            ViewBag.CityName = _homeService.List().Select(e => new SelectListItem
            {
                Text = e.CityName,
                Value = e.Id.ToString()
            });
            return View(_homeService.List());
        }

        [HttpPost]
        public IActionResult Index(string id)
        {
            return Content($"{id}");
            //return View(_cityService.GetCity(id));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

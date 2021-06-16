using System;
using System.Collections;
using System.Collections.Generic;
using Homework3.Models;
using Homework3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework3.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult List()
        {
            return View(_cityService.GetCities());
        }

        public IActionResult View(int id)
        {
            City c = _cityService.GetCity(id);
            List<string> dates = new List<string>();
            List<int> cases = new List<int>();
            List<int> tested = new List<int>();
            List<int> deaths = new List<int>();
            int population = c.Datas[c.Datas.Count-1].Population;
            foreach (var data in c.Datas)
            {
                dates.Add(data.Date.ToString("d"));
                cases.Add(data.Cases);
                tested.Add(data.Tested);
                deaths.Add(data.Deaths);

            }
            //dates.Sort();
            ViewBag.Dates = dates;
            ViewBag.Tested = tested;
            ViewBag.Deaths = deaths;
            ViewBag.Cases = cases;
            ViewBag.Population = population;
            return View(c);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string CityName, int Population)
        {
            _cityService.AddCity(CityName, Population);
            return RedirectToAction(nameof(List));
            //return Content($"{CityName} + {Population}");
        }
    }

}

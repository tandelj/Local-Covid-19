using System;
using System.Collections.Generic;
using System.IO;
using Homework3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework3.Controllers
{

    public class FilesController : Controller
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file, DateTime date)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            var lines = new List<string>();
            string line;
            while ((line = reader.ReadLine()) != null)
                lines.Add(line);
            _fileService.Import(lines, date);
            return RedirectToAction("List", "Cities");
            //_cityService.List();
            //return View("~/Views/Cities/List.cshtml");
            //return View(_cityService.GetCities());
            //return Content($"{date}");
            //_fileService.upload();
            //return View("Display", lines);
        }
    }
}

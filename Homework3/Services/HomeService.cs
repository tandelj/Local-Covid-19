using System;
using System.Collections.Generic;
using System.Linq;
using Homework3.Models;

namespace Homework3.Services
{
    public interface IHomeService
    {
        List<City>  List(); 
    }
    public class HomeService : IHomeService
    {
        private readonly AppDbContext _db;
        public HomeService(AppDbContext db)
        {
            _db = db;
        }

        List<City> IHomeService.List()
        {
            return _db.Cities.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Homework3.Models;

namespace Homework3.Services
{
    public interface ICityService
    {
        List<City> GetCities();
        void AddCity(string Name, int Population);
        City GetCity(int id);
    }
    public class CityService : ICityService
    {
        private readonly AppDbContext _db;

        public CityService(AppDbContext db)
        {
            _db = db;
        }

        public void AddCity(string Name, int Population)
        {
            City c = new City
            {
                CityName = Name
            };
            Data d = new Data
            {
                Date = DateTime.Now,
                Population = Population
            };
            try
            {
                var query = from city in _db.Cities
                            where city.CityName == Name
                            select city;
                var temp = query.FirstOrDefault().CityName;
                City ct = query.FirstOrDefault();
                ct.Datas.Add(d);
                _db.SaveChanges();
            }
            catch(Exception )
            {
                _db.Cities.Add(c);
                _db.SaveChanges();
            }
        }

        public List<City> GetCities()
        {
            return _db.Cities.ToList();
        }

        public City GetCity(int id)
        {
            City c = _db.Cities.Find(id);
            var query = from data in _db.Datas
                        where data.CityId2 == id
                        orderby data.Date
                        select data;
            List<Data> currentData = new List<Data>();
            foreach (var data in query)
            {
                currentData.Add(data);
            }
            c.Datas = currentData;
            return c;
            
            //return _db.Cities.Where(c => c.Id == id).SingleOrDefault();
            //return _db.Cities.Where(c => c.Id == id).SingleOrDefault();
            //return _db.Cities.Find(id);
        }
    }
}

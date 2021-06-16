using System;
using System.Collections.Generic;
using Homework3.Models;
using System.Linq;
//using Homework3.Services;
namespace Homework3.Services
{
    public interface IFileService
    {
        void Import(List<string> lines, DateTime date);
    }
    public class FileService : IFileService
    {
        private readonly AppDbContext _db;

        public FileService(AppDbContext db)
        {
            _db = db;
        }

        public void Import(List<string> lines, DateTime date)
        {
            int i = 0;
            foreach (var line in lines)
            {
                Console.WriteLine();
                if (i == 0) { i = 1; continue; }
                else if (i >= 1)
                {
                    i++;
                    string[] words = line.Split(new char[] { ',' });
                    string name = words[1].Trim('"');
                    //Console.WriteLine($"Found City :  {name}");
                    Data d = new Data
                    {
                        Date = date,
                        Cases = int.Parse(words[2]),
                        Deaths = int.Parse(words[5]),
                        Tested = int.Parse(words[8]),
                        Population = int.Parse(words[11])

                    };
                    //string temp = "";
                    //var db = new AppDbContext();
                    try
                    {
                        var query = from city in _db.Cities
                                    where city.CityName == name
                                    select city;
                        var temp = query.FirstOrDefault().CityName;
                        //Console.WriteLine($"temp: {temp}");
                        if (!name.ToLower().Equals(temp.ToLower()))
                        {
                            //Console.WriteLine($"City: {name} does not exsits, City Created and data added....");
                            City c = new City
                            {
                                CityName = name
                            };

                            c.Datas.Add(d);
                            _db.Cities.Add(c);
                            _db.SaveChanges();
                        }
                        else
                        {
                            //Console.WriteLine($"City: {name} exists, data added...");
                            query.FirstOrDefault().Datas.Add(d);
                            _db.SaveChanges();
                        }
                    }
                    catch (Exception)
                    {
                        //Console.WriteLine("nnnnnn");
                        //Console.WriteLine($"City: {name} does not exsits, City Created and data added....");
                        City c = new City
                        {
                            CityName = name
                        };

                        c.Datas.Add(d);
                        _db.Cities.Add(c);
                        _db.SaveChanges();
                    }
                }
                //if (i == 5) { break; }
            }
            //Console.WriteLine("\n\nData Imported.....");
      
        }
    }
}

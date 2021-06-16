using System;
using System.Collections.Generic;

namespace Homework3.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public List<Data> Datas { get; set; } = new List<Data>();

        public override string ToString() { return CityName; }
    }
}

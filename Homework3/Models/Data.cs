using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework3.Models
{
    public class Data
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public int Tested { get; set; }
        public int Population { get; set; }
        public int CityId2 { get; set; }
        [ForeignKey("CityId2")]
        public City City { get; set; }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()}\t{Cases}\t{Deaths}\t{Tested}";
        }
    }
}

using System;
using Homework3.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework3.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Data> Datas { get; set; }
    }
}

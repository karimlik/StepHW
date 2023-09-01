using System;
using Microsoft.EntityFrameworkCore;
using MinimalApiV2.Models;

namespace MinimalApiV2.Data
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
        }
    }

}


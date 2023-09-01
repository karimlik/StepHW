using System;
using MinimalAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.Data
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
        }
    }
}

using E_Commerce.Data;
using E_Commerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdmin.Services.Interfaces;

namespace AppAdmin.Services.Classes
{
    public class DataService : IDataService
    {
        private readonly DataDbContext _context;

        public DataService(DataDbContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task AddCarAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarAsync(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return;
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
    }

}

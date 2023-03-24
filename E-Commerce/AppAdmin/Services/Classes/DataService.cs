﻿using E_Commerce.Data;
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
        private readonly DataDbContext _dbContext;

        public DataService(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _dbContext.Cars.Include(c => c.User).ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _dbContext.Cars.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCarAsync(Car car)
        {
            var existingUser = await _dbContext.Users.FindAsync(car.User.Id);
            car.User = existingUser;

            _dbContext.Cars.Add(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCarAsync(Car car)
        {
            _dbContext.Cars.Update(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await _dbContext.Cars.FindAsync(id);
            if (car != null)
            {
                _dbContext.Cars.Remove(car);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

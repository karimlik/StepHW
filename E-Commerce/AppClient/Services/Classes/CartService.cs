using AppClient.ViewModels;
using E_Commerce.Data;
using E_Commerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace AppClient.Services.Classes
{
    public class ShoppingCartService
    {
        private readonly DataDbContext _dbContext;

        public ShoppingCartService(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void AddItem(CarListItemViewModel viewModel)
        {
            var car = viewModel.Car;
            CartItem existingItem = _dbContext.CartItem.FirstOrDefault(item => item.Cars.Id == car.Id);
            var cartItem = new CartItem { Id = 1, Cars = car };
            _dbContext.CartItem.Add(cartItem);
            await _dbContext.SaveChangesAsync();
        }


        public void RemoveItem(Car car)
        {
            CartItem existingItem = _dbContext.CartItem.FirstOrDefault(item => item.Cars.Id == car.Id);
            if (existingItem != null)
            {
                _dbContext.CartItem.Remove(existingItem);
            }
        }
    }
}

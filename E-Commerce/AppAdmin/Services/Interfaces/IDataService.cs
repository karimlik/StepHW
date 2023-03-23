using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAdmin.Services.Interfaces
{
    public interface IDataService
    {
        Task<List<Car>> GetCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task AddCarAsync(Car car);
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(int id);
    }

}

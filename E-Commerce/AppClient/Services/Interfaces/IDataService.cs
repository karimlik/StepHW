using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClient.Services.Interfaces
{
    public interface IDataService
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task AddCarAsync(Car car);
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(int id);

        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }

}

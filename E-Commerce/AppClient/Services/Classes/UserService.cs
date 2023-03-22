using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Data;
using E_Commerce.Data.Models;

namespace AppClient.Services.Classes
{
    public class UserService
    {
        private readonly DataDbContext _dbContext;

        public UserService()
        {
            _dbContext = new DataDbContext();
        }

        public User Login(string email, string password)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public void Register(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
}

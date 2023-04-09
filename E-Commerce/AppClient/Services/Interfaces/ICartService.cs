using AppClient.Services.Classes;
using AppClient.ViewModels;
using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClient.Services.Interfaces
{
    public interface ICartService
    {
        void AddItem(CarListItemViewModel car);
        void RemoveItem(Car car);
        void Clear();
        List<CartItem> GetItems();
    }
}

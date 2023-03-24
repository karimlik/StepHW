using E_Commerce.Data.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using AppClient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClient.ViewModels
{
    public class CarListViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        public ObservableCollection<Car> Cars { get; set; }

        public CarListViewModel(IDataService dataService)
        {
            _dataService = dataService;
            LoadCars();
        }

        private async void LoadCars()
        {
            Cars = new ObservableCollection<Car>(await _dataService.GetAllCarsAsync());
        }
    }

}

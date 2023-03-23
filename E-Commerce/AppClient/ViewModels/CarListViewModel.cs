using AppClient.Services.Classes;
using AppAdmin.Services.Classes;
using AppAdmin.Services.Interfaces;
using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Security;

namespace CarInventory.ViewModels
{
    public class CarListViewModel : INotifyPropertyChanged
    {
        private readonly IDataService _dataService;
        private ObservableCollection<Car> _cars;

        public CarListViewModel(IDataService dataService)
        {
            _dataService = dataService;
            LoadCars();
        }

        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }

        private async void LoadCars()
        {
            Cars = new ObservableCollection<Car>(await _dataService.GetCarsAsync());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

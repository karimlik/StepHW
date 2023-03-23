using E_Commerce.Data.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AppClient.Services;
using AppClient.Components;
using AppAdmin.View;
using AppAdmin.ViewModels;
using E_Commerce.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AppAdmin.Services.Interfaces;
using AppAdmin.Services.Classes;
using GalaSoft.MvvmLight.Messaging;

namespace AppAdmin.ViewModels
{
    public class CarFormViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly bool _isNewCar;
        private int _carId;
        private string _carMake;
        private string _carModel;
        private int _carYear;
        private decimal _carPrice;
        private string _carImgUrl;

        public CarFormViewModel(IDataService dataService, Car car = null)
        {
            _dataService = dataService;

            if (car == null)
            {
                _isNewCar = true;
                Title = "Add New Car";
                CarImgUrl = "default.jpg"; // Set a default image
            }
            else
            {
                _isNewCar = false;
                Title = "Edit Car";
                CarId = car.Id;
                CarMake = car.Make;
                CarModel = car.Model;
                CarYear = car.Year;
                CarPrice = car.Price;
                CarImgUrl = car.imgUrl;
            }
        }

        public int CarId
        {
            get { return _carId; }
            set { SetProperty(ref _carId, value); }
        }

        public string CarMake
        {
            get { return _carMake; }
            set { SetProperty(ref _carMake, value); }
        }

        public string CarModel
        {
            get { return _carModel; }
            set { SetProperty(ref _carModel, value); }
        }

        public int CarYear
        {
            get { return _carYear; }
            set { SetProperty(ref _carYear, value); }
        }

        public decimal CarPrice
        {
            get { return _carPrice; }
            set { SetProperty(ref _carPrice, value); }
        }

        public string CarImgUrl
        {
            get { return _carImgUrl; }
            set { SetProperty(ref _carImgUrl, value); }
        }

        public string Title { get; }

        public RelayCommand SaveCarCommand { get; private set; }

        private async void SaveCar()
        {
            var car = new Car
            {
                Id = CarId,
                Make = CarMake,
                Model = CarModel,
                Year = CarYear,
                Price = CarPrice,
                imgUrl = CarImgUrl
            };

            if (_isNewCar)
            {
                await _dataService.AddCarAsync(car);
            }
            else
            {
                await _dataService.UpdateCarAsync(car);
            }

            MessengerInstance.Send(new NotificationMessage("Car saved."));
        }

        public void Initialize()
        {
            SaveCarCommand = new RelayCommand(SaveCar);
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

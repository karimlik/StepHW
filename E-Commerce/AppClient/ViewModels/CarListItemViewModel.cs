using E_Commerce.Data.Models;
using System;
using System.ComponentModel;

namespace AppClient.ViewModels
{
    public class CarListItemViewModel
    {
        public string Make => Car.Make;
        public string Model => Car.Model;
        public int Year => Car.Year;
        public int Mileage => Car.Mileage;
        public decimal Price => Car.Price;
        public string ImageUrl => Car.imgUrl;

        private Car _car;
        public Car Car
        {
            get { return _car; }
            set
            {
                if (_car != value)
                {
                    _car = value;
                    RaisePropertyChanged(nameof(Car));
                    RaisePropertyChanged(nameof(Make));
                    RaisePropertyChanged(nameof(Model));
                    RaisePropertyChanged(nameof(Year));
                    RaisePropertyChanged(nameof(Mileage));
                    RaisePropertyChanged(nameof(Price));
                    RaisePropertyChanged(nameof(ImageUrl));
                }
            }
        }

        public CarListItemViewModel(Car car)
        {
            Car = car ?? throw new ArgumentNullException(nameof(car));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
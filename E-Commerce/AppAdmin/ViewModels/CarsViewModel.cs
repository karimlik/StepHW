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
using E_Commerce.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppAdmin.ViewModels
{
    // ...

    public class CarsViewModel : ViewModelBase
    {
        private readonly DataDbContext _context;
        private readonly ObservableCollection<Car> _cars;

        public CarsViewModel()
        {
            _context = new DataDbContext();
            _cars = new ObservableCollection<Car>(_context.Cars.ToList());
        }

        public ObservableCollection<Car> Cars
        {
            get { return _cars; }
        }

        private Car _selectedCar;

        public Car SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                if (_selectedCar != value)
                {
                    _selectedCar = value;
                    OnPropertyChanged(nameof(SelectedCar));
                }
            }
        }

        public RelayCommand AddCarCommand { get; set; }
        public RelayCommand EditCarCommand { get; set; }
        public RelayCommand DeleteCarCommand { get; set; }

        private void AddCar()
        {
            Car car = new Car();
            var viewModel = new CarFormViewModel(_context, car);
            var window = new CarFormView { DataContext = viewModel };

            bool? result = window.ShowDialog();

            if (result == true)
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
                _cars.Add(car);
            }
        }

        private void EditCar()
        {
            if (SelectedCar != null)
            {
                var viewModel = new CarFormViewModel(_context, SelectedCar);
                var window = new CarFormView { DataContext = viewModel };

                bool? result = window.ShowDialog();

                if (result == true)
                {
                    _context.SaveChanges();
                }
            }
        }

        private void DeleteCar()
        {
            if (SelectedCar != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this car?",
                                                          "Confirm Delete",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _context.Cars.Remove(SelectedCar);
                    _context.SaveChanges();
                    _cars.Remove(SelectedCar);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}

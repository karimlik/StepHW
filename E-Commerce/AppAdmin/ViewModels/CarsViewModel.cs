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
using AppAdmin.Services.Interfaces;

namespace AppAdmin.ViewModels
{

    public class CarsViewModel : ViewModelBase
    {
        private readonly DataDbContext _context;
        private readonly IDataService _dataService;
        private ObservableCollection<Car> _cars;

        public CarsViewModel()
        {
            _context = new DataDbContext();
            _cars = new ObservableCollection<Car>(_context.Cars.ToList());
            AddCommand = new RelayCommand(AddCar);
            EditCommand = new RelayCommand(EditCar);
            DeleteCommand = new RelayCommand(DeleteCar);
            UpdateCommand = new RelayCommand(UpdateList);
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

        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        private void AddCar()
        {
            Car car = new Car();
            CarFormView window = new CarFormView();

            bool? result = window.ShowDialog();

            _cars.Add(car);
        }

        private void EditCar()
        {
            if (SelectedCar != null)
            {
                CarFormView window = new CarFormView();

                bool? result = window.ShowDialog();

                /*if (result == true)
                {
                    _context.SaveChanges();
                }*/
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

        private void UpdateList()
        {
            _cars = new ObservableCollection<Car>(_context.Cars.ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
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
using AppAdmin.Services.Classes;
using Intuit.Ipp.DataService;
using IDataService = AppAdmin.Services.Interfaces.IDataService;
using AppClient.Services.Classes;
using DataService = AppAdmin.Services.Classes.DataService;
using Intuit.Ipp.Data;
using Microsoft.EntityFrameworkCore;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

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
            _dataService = new DataService(_context);
            _cars = new ObservableCollection<Car>(_context.Cars.Include(u => u.User).ToList());
            AddCommand = new RelayCommand(AddCar);
            EditCommand = new RelayCommand(EditCar);
            DeleteCommand = new RelayCommand(DeleteCarAsync);
            UpdateCommand = new RelayCommand(LoadCars);
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

        private string _searchQuery;

        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    SearchCars();
                }
            }
        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }

        private void AddCar()
        {
            var car = new Car();
            var viewModel = new CarFormViewModel(_dataService, car);
            var form = new CarFormView(viewModel);
            form.ShowDialog();
            if (viewModel.IsSaved())
            {

                Cars.Add(viewModel.Car);
            }
        }

        private void EditCar()
        {
            var viewModel = new CarFormViewModel(_dataService, SelectedCar);
            var form = new CarFormView(viewModel);
            form.ShowDialog();
            if (viewModel.IsSaved())
            {
                var index = Cars.IndexOf(SelectedCar);
                Cars[index] = viewModel.Car;
            }
        }

        private async void DeleteCarAsync()
        {
            var result = MessageBox.Show("Are you sure you want to delete this car?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                await _dataService.DeleteCarAsync(SelectedCar.Id);
                Cars.Remove(SelectedCar);
            }
        }

        private async void LoadCars()
        {
            Cars = new ObservableCollection<Car>(await _dataService.GetAllCarsAsync());
        }

        private void SearchCars()
        {
            Cars = new ObservableCollection<Car>(_context.Cars.Include(u => u.User).Where(c => c.Make.Contains(SearchQuery)).ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
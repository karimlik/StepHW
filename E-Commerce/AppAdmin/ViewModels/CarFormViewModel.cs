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
using Microsoft.EntityFrameworkCore;
using Intuit.Ipp.Data;
using User = E_Commerce.Data.Models.User;

namespace AppAdmin.ViewModels
{
    public class CarFormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly DataDbContext _context;
        private readonly IDataService _dataService;

        private Car _car;
        public Car Car
        {
            get { return _car; }
            set
            {
                _car = value;
                OnPropertyChanged(nameof(Car));
            }
        }

        private User Users { get; set; }

        public ICommand SaveCommand { get; }

        public CarFormViewModel(IDataService dataService, Car car = null)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _car = car ?? new Car();
            _context = new DataDbContext();
            SaveCommand = new RelayCommand(SaveCarAsync);
        }

        private async void SaveCarAsync()
        {
            if (_car.Id == 0)
            {
                _car.User = _context.Users.FirstOrDefault(u => u.Email == _userEmail);
                await _dataService.AddCarAsync(_car);
            }
            else
            {
                await _dataService.UpdateCarAsync(_car);
            }
            MessageBox.Show("Close this window to see changes!");
        }

        public bool IsSaved()
        {
            if (_car == null || _car.Id == 0)
            {
                return false;
            }
            return true;
        }

        private string _userEmail;
        public string UserEmail
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
                OnPropertyChanged(nameof(_userEmail));
            }

        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

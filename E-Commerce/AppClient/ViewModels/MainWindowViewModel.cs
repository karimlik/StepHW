using AppClient.Services.Classes;
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

namespace AppClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly UserService _userService;

        public MainWindowViewModel()
        {
            _userService = new UserService();
            LoginCommand = new RelayCommand(Login, CanLogin);
            RegisterCommand = new RelayCommand(Register, true);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        private bool CanLogin()
        {
            return string.IsNullOrWhiteSpace(Email) && string.IsNullOrWhiteSpace(Password);
        }

        private bool CanRegister()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
        }

        private void Login()
        {
            User user = _userService.Login(Email, EncryptPassword(Password));

            if (user != null)
            {
                MessageBox.Show($"Welcome, {user.Name}!");
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }

        private void Register()
        {
            User user = new User
            {
                Name = Name,
                Email = Email,
                Password = EncryptPassword(Password)
            };

            _userService.Register(user);
            MessageBox.Show("Registration successful!");
        }

        private string EncryptPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    hash.Append(b.ToString("x2"));
                }
                return hash.ToString();
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

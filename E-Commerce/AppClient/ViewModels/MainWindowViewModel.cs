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
            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);
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

        private string _phonenumber;
        public string PhoneNumber
        {
            get { return _phonenumber; }
            set
            {
                _phonenumber = value;
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

        private string _passwordConfirm;
        public string PasswordConfirm
        {
            get { return _passwordConfirm; }
            set
            {
                _passwordConfirm = value;
                OnPropertyChanged(nameof(PasswordConfirm));
            }
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private bool CanRegister()
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        private void Login()
        {
            User user = _userService.Login(Email, EncryptPassword(Password));

            if (user != null)
            {
                MessageBox.Show($"Welcome, {user.Name}!");
                new CarInventoryView().Show();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }

        private void Register()
        {
            
            if (!_userService.CheckExists(_email, EncryptPassword(Password)))
            {
                User user = new User
                {
                    Name = Name,
                    Email = Email,
                    PhoneNumber = PhoneNumber,
                    Password = EncryptPassword(Password)
                };

                _userService.Register(user);
                MessageBox.Show("Registration successful! Proceed to Log In!");
            }
            else
            {
                MessageBox.Show("Error!");
                return;
            }
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

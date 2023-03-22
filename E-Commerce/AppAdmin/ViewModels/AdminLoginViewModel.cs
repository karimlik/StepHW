using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Security.Cryptography;
using AppClient.Services.Classes;
using E_Commerce.Data.Models;

namespace AppAdmin.ViewModels
{
    class AdminLoginViewModel : ViewModelBase
    {
        private readonly UserService _userService;

        public AdminLoginViewModel()
        {
            _userService = new UserService();
            LoginCommand = new RelayCommand(Login);
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

        private void Login()
        {
            User user = _userService.Login(Email, EncryptPassword(Password));

            if (user != null && user.IsAdmin == true && user.AdminLevel != 0)
            {
                MessageBox.Show($"Welcome, {user.Name}!");
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
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

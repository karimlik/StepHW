using AppClient.Services.Classes;
using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Security.Cryptography;
using E_Commerce.Data;

namespace AppClient.ViewModels
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void OnLoginButtonClicked(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginView();
            this.Close();
            loginWindow.Show();
        }

        private void OnRegisterButtonClicked(object sender, RoutedEventArgs e)
        {

        }

    }
}

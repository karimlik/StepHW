using AppClient.Services.Classes;
using AppClient.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace AppClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnRegisterButtonClicked(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterView();
            this.Close();
            registerWindow.Show();
        }

        private void OnLoginButtonClicked(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginView();
            this.Close();
            loginWindow.Show();
        }
    }
}

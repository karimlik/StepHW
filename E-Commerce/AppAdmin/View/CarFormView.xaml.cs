using AppAdmin.ViewModels;
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
using AppAdmin.ViewModels;
using AppAdmin.Services.Interfaces;
using E_Commerce.Data.Models;
using System.Runtime.ConstrainedExecution;
using E_Commerce.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AppAdmin.View
{
    /// <summary>
    /// Interaction logic for CarFormView.xaml
    /// </summary>
    public partial class CarFormView : Window
    {
        private DataDbContext _context;

        public CarFormView()
        {
            InitializeComponent();
        }

        private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
        {
            _context = new DataDbContext();
            Car _cars = new Car();
            int userId = int.Parse(UserIdTextBox.Text);
            User _user = _context.Users.FirstOrDefault(u => u.Id == userId);
            _cars.Make = MakeTextBox.Text;
            _cars.Model = ModelTextBox.Text;
            _cars.Year = int.Parse(YearTextBox.Text);
            _cars.Mileage = int.Parse(MileageTextBox.Text);
            _cars.Price = decimal.Parse(PriceTextBox.Text);
            _cars.imgUrl = ImgTextBox.Text;
            _cars.SellerName = UserNameTextBox.Text;
            _cars.SellerPhone = PhoneTextBox.Text;
            _cars.User = _user;

            _context.Cars.Add(_cars);
            _context.SaveChanges();

            this.Close();
        }
    }
}

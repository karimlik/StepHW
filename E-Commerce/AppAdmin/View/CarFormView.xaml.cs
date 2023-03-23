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

namespace AppAdmin.View
{
    /// <summary>
    /// Interaction logic for CarFormView.xaml
    /// </summary>
    public partial class CarFormView : Window
    {
        private CarFormViewModel _viewModel;

        public CarFormViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }
        public CarFormView(IDataService dataService, Car car = null)
        {
            InitializeComponent();
            ViewModel = new CarFormViewModel(dataService, car);
        }

        private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
        {
            CarFormView();
            this.Close();
        }
    }
}

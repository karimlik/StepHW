using AppClient.ViewModels;
using E_Commerce.Data.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AppClient.Components
{
    public partial class CarListItem : UserControl
    {
        private CarListItemViewModel viewModel;
        public Car Car { get; set; }

        public CarListItem()
        {
            InitializeComponent();
        }

        public CarListItemViewModel SetCar(Car car)
        {
            Car = car;
            viewModel = new CarListItemViewModel(car);
            DataContext = viewModel;
            return viewModel;
        }
    }
}

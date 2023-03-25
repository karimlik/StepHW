using AppClient.ViewModels;
using E_Commerce.Data.Models;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AppClient.Components
{
    public partial class CarListItem : UserControl
    {
        public static readonly DependencyProperty CarProperty =
    DependencyProperty.Register("Car", typeof(Car), typeof(CarListItem), new PropertyMetadata(null));

        private CarListItemViewModel viewModel;
        public Car Car
        {
            get { return (Car)GetValue(CarProperty); }
            set { SetValue(CarProperty, value); }
        }

        public CarListItem()
        {
            InitializeComponent();
        }

        public CarListItemViewModel SetCar(Car car)
        {
            Car = car;
            viewModel = new CarListItemViewModel(car);
            return viewModel;
        }
    }
}

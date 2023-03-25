using AppClient.ViewModels;
using E_Commerce.Data.Models;
using MaterialDesignThemes.Wpf;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AppClient.Components
{
    public partial class CarListItem : UserControl
    {
        private CarListItemViewModel viewModel;
        private Car _car;
        public Car Car
        {
            get { return _car; }
            set { _car = value; RaisePropertyChanged(nameof(Car)); }
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

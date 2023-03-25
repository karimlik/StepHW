using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using E_Commerce.Data.Models;
using AppClient.Services;
using AppClient.Components;
using AppClient.Services.Interfaces;

namespace AppClient.ViewModels
{
    public class CarListViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        public CarListViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Cars = new ObservableCollection<CarListItemViewModel>();
            LoadCarsCommand = new RelayCommand(async () => await LoadCarsAsync());
        }

        private ObservableCollection<CarListItemViewModel> _cars;
        public ObservableCollection<CarListItemViewModel> Cars
        {
            get { return _cars; }
            set { Set(ref _cars, value); }
        }

        public RelayCommand LoadCarsCommand { get; }

        public async Task LoadCarsAsync()
        {
            var cars = await _dataService.GetAllCarsAsync();

            Cars.Clear();
            foreach (var car in cars)
            {
                var _window = new CarListItem();
                var _viewModel = _window.SetCar(car);
                Cars.Add(_viewModel);
            }
        }
    }
}

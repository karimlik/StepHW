using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using E_Commerce.Data.Models;
using AppClient.Services;
using AppClient.Components;
using AppClient.Services.Interfaces;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppClient.View;

namespace AppClient.ViewModels
{
    public class CarListViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        private string _searchText;
        public string SearchQuery
        {
            get { return _searchText; }
            set
            {
                if (Set(ref _searchText, value))
                {
                    SearchCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public CarListViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Cars = new ObservableCollection<CarListItemViewModel>();
            LoadCarsCommand = new RelayCommand(async () => await LoadCarsAsync());
            SearchCommand = new RelayCommand(SearchCars);
        }

        private ObservableCollection<CarListItemViewModel> _cars;
        public ObservableCollection<CarListItemViewModel> Cars
        {
            get { return _cars; }
            set { Set(ref _cars, value); }
        }

        public RelayCommand SearchCommand { get; set; }
        public RelayCommand LoadCarsCommand { get; }

        public async Task LoadCarsAsync()
        {
            var cars = await _dataService.GetAllCarsAsync();

            Cars.Clear();
            foreach (var car in cars)
            {
                var viewModel = new CarListItemViewModel(car);
                Cars.Add(viewModel);
            }
        }

        private async void SearchCars()
        {
            var cars = await _dataService.SearchCarsAsync(SearchQuery);
            Cars.Clear();
            foreach (var car in cars)
            {
                var viewModel = new CarListItemViewModel(car);
                Cars.Add(viewModel);
            }
        }
    }
}

using E_Commerce.Data.Models;
using GalaSoft.MvvmLight;

namespace AppClient.Components
{
    public class CarListItemViewModel : ViewModelBase
    {
        private readonly Car _car;

        public CarListItemViewModel(Car car)
        {
            _car = car;
        }

        public string ImageUrl => _car.imgUrl;

        public string Make => _car.Make;

        public string Model => _car.Model;

        public int Year => _car.Year;

        public int Mileage => _car.Mileage;

        public decimal Price => _car.Price;
    }
}

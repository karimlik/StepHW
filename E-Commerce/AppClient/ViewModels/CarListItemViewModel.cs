﻿using E_Commerce.Data.Models;

namespace AppClient.ViewModels
{
    public class CarListItemViewModel
    {

        public Car Car { get; set; }

        public string Make => "BMW";
        public string Model => Car.Model;
        public int Year => Car.Year;
        public int Mileage => Car.Mileage;
        public decimal Price => Car.Price;
        public string ImageUrl => Car.imgUrl;

        public CarListItemViewModel()
        {
            // Default parameterless constructor
        }

        public CarListItemViewModel(Car car)
        {
            Car = car;
        }
    }
}
using AppClient.Services.Classes;
using AppClient.Services.Interfaces;
using AppClient.ViewModels;
using CommonServiceLocator;
using E_Commerce.Data;
using E_Commerce.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AppClient.Components
{
    public partial class CarListItem : UserControl
    {
        private readonly DataDbContext _context;
        private ShoppingCartService _cartService;

        public CarListItem()
        {
            InitializeComponent();
            _context = new DataDbContext();
            _cartService = new ShoppingCartService(_context);
        }

        private void onAddClicked(object sender, RoutedEventArgs e)
        {
            var viewModel = (sender as FrameworkElement).DataContext as CarListItemViewModel;


            _cartService.AddItem(viewModel);

            // Show a confirmation message to the user
            MessageBox.Show($"Added {viewModel.Car.Make} to cart!");
        }

    }
}

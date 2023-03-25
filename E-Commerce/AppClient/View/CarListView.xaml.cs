using AppClient.Services.Classes;
using AppClient.Services.Interfaces;
using AppClient.ViewModels;
using E_Commerce.Data;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Controls;

namespace AppClient.View
{
    public partial class CarListView : Window
    {
        private readonly DataDbContext _context;
        private readonly IDataService _dataService;
        public CarListView()
        {
            InitializeComponent();
            _context = new DataDbContext();
            _dataService = new DataService(_context);  
            DataContext = new CarListViewModel(_dataService);
            Messenger.Default.Register<NotificationMessage>(this, (message) =>
            {
                if (message.Notification == "CloseWindow")
                {
                    Close();
                }
            });
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var selectedItem = e.AddedItems[0];
                ((ListView)sender).SelectedItem = null;
                Messenger.Default.Send(new NotificationMessage<object>(selectedItem, "OpenCarDetails"));
            }
        }
    }
}
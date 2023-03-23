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

namespace AppAdmin.View
{
    /// <summary>
    /// Interaction logic for CRUDView.xaml
    /// </summary>
    public partial class CRUDView : Window
    {
        public CRUDView()
        {
            InitializeComponent();
            DataContext = new CarsViewModel();
        }

        private void OnAddButtonClicked(object sender, RoutedEventArgs e)
        {
            CarFormView window = new CarFormView();

            bool? result = window.ShowDialog();

            Close();
        }
    }
}

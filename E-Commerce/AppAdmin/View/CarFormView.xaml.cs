using AppAdmin.ViewModels;
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
using AppAdmin.Services.Interfaces;
using E_Commerce.Data.Models;
using System.Runtime.ConstrainedExecution;
using E_Commerce.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;

namespace AppAdmin.View
{
    public partial class CarFormView : Window
    {
        public CarFormView(CarFormViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
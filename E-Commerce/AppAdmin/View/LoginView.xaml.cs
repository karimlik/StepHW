using System.Windows;
using AppAdmin.ViewModels;
namespace AppAdmin.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new AdminLoginViewModel();
        }
    }
}

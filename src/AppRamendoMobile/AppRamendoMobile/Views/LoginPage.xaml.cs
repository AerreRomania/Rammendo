using AppRammendoMobile.ViewModels;
using Xamarin.Forms;

namespace AppRammendoMobile.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            BindingContext = new LoginViewModel();
            InitializeComponent();
        }
    }
}

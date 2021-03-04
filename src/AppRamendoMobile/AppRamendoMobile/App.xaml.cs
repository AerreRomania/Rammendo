using AppRammendoMobile.Services;
using AppRammendoMobile.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppRammendoMobile
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<ICameraScanner>();
            DependencyService.Register<ApiClient>();
            DependencyService.Register<LoginClient>();

            InitializeComponent();

            Permissions.RequestAsync<Permissions.Camera>();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

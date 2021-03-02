using AppRammendoMobile.Services;
using AppRammendoMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRammendoMobile
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<ICameraScanner>();


            InitializeComponent();
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

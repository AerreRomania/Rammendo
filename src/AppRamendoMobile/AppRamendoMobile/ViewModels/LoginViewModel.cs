using AppRammendoMobile.Models;
using AppRammendoMobile.Settings;
using AppRammendoMobile.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRammendoMobile.ViewModels
{
   public class LoginViewModel : ViewModelBase
    {  
        public ICommand LoginCommand { get; set; }
        public ICommand ScanQrCodeCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
            ScanQrCodeCommand = new Command(async () => await ExecuteScanQRCodeCommand());
        }

        private async Task ExecuteScanQRCodeCommand()
        {           
            try 
            {
                IsBusy = true;
                CodAngajat = await CameraScanner.ScanAsync();
                await LoginUser(CodAngajat);
                IsBusy = false;
            }
            catch (Exception ex) 
            {
                if (IsBusy) IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }     
        }

        private async Task ExecuteLoginCommand()
        {
            try
            {
                IsBusy = true;
                await LoginUser(CodAngajat);
                IsBusy = false;
            }
            catch (Exception ex) 
            {
                if (IsBusy) IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
        }

        private async Task LoginUser(string codAngajat) 
        {
            if (codAngajat != null) 
            {
                Angajati angajati = await Loginclient.LoginUserAsync($"{Url}login?codAngajat={CodAngajat}");
                angajati.Action = "work";
                await ApiClient.InsertAsync(angajati, $"{Url}RammendoLog");     //this line is for inserting login or pause time

                if (angajati != null)
                { 
                    if(angajati.CodAngajat!=AppSettings.Pin)
                    {
                        AppSettings.Pin = angajati.CodAngajat;
                        AppSettings.TotalQty = 0;
                    }
                    TotalQty = AppSettings.TotalQty;
                    await Application.Current.MainPage.DisplayAlert("Success login", angajati.Angajat, "ok");
                    await Application.Current.MainPage.Navigation.PushAsync(new JobSelectionPage(angajati));
                }
                else 
                {
                    await Application.Current.MainPage.DisplayAlert("Login error", $"No access for code {CodAngajat}", "ok");
                }
            }
            else 
            {            
                await Application.Current.MainPage.DisplayAlert("No code", "Please scan again.", "ok");
            }
               
        }
        private string _codAngajat = string.Empty;
        public string CodAngajat
        {
            get => _codAngajat;
            set => SetProperty(ref _codAngajat, value);
        }
    }
}

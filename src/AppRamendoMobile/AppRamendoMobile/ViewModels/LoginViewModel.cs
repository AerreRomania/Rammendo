using AppRammendoMobile.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRammendoMobile.ViewModels
{
   public class LoginViewModel : ViewModelBase
    {
        private string _codAngajat = string.Empty;

        public ICommand LoginCommand { get; set; }
        public ICommand ScanQrCodeCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
            ScanQrCodeCommand = new Command(async () => await ExecuteScanQRCodeCommand());
        }

        private async Task ExecuteScanQRCodeCommand()
        {
            try {
                CodAngajat = await CameraScanner.ScanAsync();
                await LoginUser(CodAngajat);
            }
            catch (Exception ex) {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }     
        }

        private async Task ExecuteLoginCommand()
        {
            try {
                await LoginUser(CodAngajat);
            }
            catch (Exception ex) {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
        }

        private async Task LoginUser(string codAngajat) {

            if (codAngajat != null) {
                var angajati = await Loginclient.LoginUserAsync($"{Url}login=codAngajat={CodAngajat}");

                if (angajati != null) {
                    await Application.Current.MainPage.DisplayAlert("Success login", angajati.Angajat, "ok");
                    await Application.Current.MainPage.Navigation.PushAsync(new JobSelectionPage(angajati));
                }
                else {

                    await Application.Current.MainPage.DisplayAlert("Login error", $"No access for code {CodAngajat}", "ok");
                }
            }
            else {
                
                await Application.Current.MainPage.DisplayAlert("No code", "Please scan again.", "ok");
            }
               
        }

        public string CodAngajat
        {
            get => _codAngajat;
            set => SetProperty(ref _codAngajat, value);
        }
    }
}

using AppRammendoMobile.Models;
using AppRammendoMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRammendoMobile.ViewModels
{
    public class JobSelectionViewModel : ViewModelBase
    {
        public ICommand CapiCommand { get; set; }
        public ICommand TelliCommand { get; set; }
        public ICommand QrCommessaCommand { get; set; }
        public ICommand QrTavolaCommand { get; set; }
     
        public JobSelectionViewModel()
        {
            CapiCommand = new Command(async() => await ExecuteCapiCommand());
            TelliCommand = new Command(async () => await ExecuteTelliCommand());
            QrCommessaCommand = new Command(async () =>await ExecuteQrCommessaCommand());
            QrTavolaCommand = new Command(async () =>await ExecuteQrTavoloCommand());
        }

        public JobSelectionViewModel(Angajati angajati) 
        {
            User = angajati;
            CapiCommand = new Command(async () =>await ExecuteCapiCommand());
            TelliCommand = new Command(async () => await ExecuteTelliCommand());
            QrCommessaCommand = new Command(async () => await ExecuteQrCommessaCommand());
            QrTavolaCommand = new Command(async () => await ExecuteQrTavoloCommand());
        }

        private async Task ExecuteQrCommessaCommand()
        {
            try
            {
                CommessaString = await CameraScanner.ScanAsync();
                Commessa = await ApiClient.PostAsync<RammendoImport>(Url + "rammendoimport?barcode=" + CommessaString);
                await Application.Current.MainPage.DisplayAlert("Scanned commessa", Commessa.Commessa, "ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
        }

        private async Task ExecuteQrTavoloCommand()
        {
            try
            {
                TavoloString = await CameraScanner.ScanAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
        }

        private async Task ExecuteTelliCommand()
        {
            if (Commessa == null || TavoloString == null) {
                await Application.Current.MainPage.DisplayAlert("Error", "Tavolo and barcode must be scanned", "ok");
                return;
            }

            Commessa.Tavolo = TavoloString;

            await Application.Current.MainPage.Navigation.PushAsync(new WorkPage(User ,Commessa, string.Empty));
        }

        private async Task ExecuteCapiCommand()
        {
            if (Commessa == null || TavoloString == null) {
                await Application.Current.MainPage.DisplayAlert("Error", "Tavolo and barcode must be scanned", "ok");
                return;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new RepartoSelectionPage(User,Commessa));
        }
    }
}

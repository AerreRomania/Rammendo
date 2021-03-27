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
        public ICommand TypeBarcodeCommand { get; set; }
        public ICommand ExitCommand { get; set; }
     
        public JobSelectionViewModel()
        {
            CapiCommand = new Command(async() => await ExecuteCapiCommand());
            TelliCommand = new Command(async () => await ExecuteTelliCommand());
            QrCommessaCommand = new Command(async () =>await ExecuteQrCommessaCommand());
            QrTavolaCommand = new Command(async () =>await ExecuteQrTavoloCommand());
            TypeBarcodeCommand = new Command(async () => await ExecuteTypeBarcodeCommand());
            ExitCommand = new Command(async () => await ExecuteExitCommand());
        }

       

        public JobSelectionViewModel(Angajati angajati) 
        {
            User = angajati;
            CapiCommand = new Command(async () =>await ExecuteCapiCommand());
            TelliCommand = new Command(async () => await ExecuteTelliCommand());
            QrCommessaCommand = new Command(async () => await ExecuteQrCommessaCommand());
            QrTavolaCommand = new Command(async () => await ExecuteQrTavoloCommand());
            TypeBarcodeCommand = new Command(async () => await ExecuteTypeBarcodeCommand());
            ExitCommand = new Command(async () => await ExecuteExitCommand());
        }
        private async Task ExecuteExitCommand()
        {
            try
            {
                bool result = await Application.Current.MainPage.DisplayAlert("Log-out ?", "Are you sure you want to logout ?", "Yes", "No");
                if (result)
                {
                    User.Action = "work";
                    await ApiClient.UpdateAsync(User, $"{Url}RammendoLog/1");   // this line is for logout or end pause depends on action
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
        }
        private async Task ExecuteTypeBarcodeCommand()
        {
            try
            {
                if (CommessaString.Substring(0, 1) == "0") CommessaString = CommessaString.Remove(0, 1); 
                Rammendo = await ApiClient.PostAsync<RammendoImport>(Url + "rammendoimport?barcode=" + CommessaString);
                if (Rammendo != null)
                {
                    Rammendo.Angajat = User.Angajat;
                    Rammendo.Tavolo = TavoloString;
                }
                await Application.Current.MainPage.DisplayAlert("Scanned commessa", Rammendo.Commessa, "ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
        }

        private async Task ExecuteQrCommessaCommand()
        {
            try
            {
                CommessaString = await CameraScanner.ScanAsync();
                if (CommessaString.Substring(0, 1) == "0") CommessaString = CommessaString.Remove(0, 1);
                Rammendo = await ApiClient.PostAsync<RammendoImport>(Url + "rammendoimport?barcode=" + CommessaString);
                if (Rammendo != null)
                {
                    Rammendo.Angajat = User.Angajat;
                    Rammendo.Tavolo = TavoloString;
                }
                await Application.Current.MainPage.DisplayAlert("Scanned commessa", Rammendo.Commessa, "ok");
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
                Rammendo.Tavolo = TavoloString;
                Rammendo.Angajat = User.Angajat;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
        }

        private async Task ExecuteTelliCommand()
        {
            if (Rammendo == null || TavoloString == null) {
                await Application.Current.MainPage.DisplayAlert("Error", "Tavolo and barcode must be scanned", "ok");
                return;
            }

            Rammendo.TypeOfControl = "Telli";
            Rammendo.StartJob = DateTime.Now;
            await Application.Current.MainPage.Navigation.PushAsync(new WorkPage(Rammendo, User));
        }

        private async Task ExecuteCapiCommand()
        {
            if (Rammendo == null || TavoloString == null) {
                await Application.Current.MainPage.DisplayAlert("Error", "Tavolo and barcode must be scanned", "ok");
                return;
            }
            Rammendo.TypeOfControl = "Capi";
            Rammendo.StartJob = DateTime.Now;
            await Application.Current.MainPage.Navigation.PushAsync(new RepartoSelectionPage(Rammendo, User));
        }
    }
}

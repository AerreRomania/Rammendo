﻿using AppRammendoMobile.Models;
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
            CapiCommand = new Command(() => ExecuteCapiCommand());
            TelliCommand = new Command(() => ExecuteTelliCommand());
            QrCommessaCommand = new Command(async () =>await ExecuteQrCommessaCommand());
            QrTavolaCommand = new Command(async () =>await ExecuteQrTavoloCommand());
        }

        public JobSelectionViewModel(Angajati angajati) 
        {
            User = angajati;
            CapiCommand = new Command(() => ExecuteCapiCommand());
            TelliCommand = new Command(() => ExecuteTelliCommand());
        }

        private async Task ExecuteQrCommessaCommand()
        {
            try
            {
                CommessaString = await CameraScanner.ScanAsync();
                Commessa = await ApiClient.GetAsync<Commesse>(Url + "barcode?=" + CommessaString);
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

        private async void ExecuteTelliCommand()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new WorkPage(Commessa, string.Empty));
        }

        private async void ExecuteCapiCommand()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new RepartoSelectionPage(Commessa));
        }

        
            

    }
}

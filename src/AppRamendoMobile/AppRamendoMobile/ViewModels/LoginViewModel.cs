﻿using AppRammendoMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRammendoMobile.ViewModels
{
   public class LoginViewModel:ViewModelBase
    {
        public ICommand LoginCommand { get; set; }
        public ICommand ScanQrCodeCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(() => ExecuteLoginCommand());
            ScanQrCodeCommand = new Command(() => ExecuteScanQRCodeCommand());
        }

        private void ExecuteScanQRCodeCommand()
        {
            throw new NotImplementedException();
        }

        private void ExecuteLoginCommand()
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new JobSelectionPage());
        }

        private string _CodAngajat = string.Empty;
        public string CodAngajat
        {
            get => _CodAngajat;
            set
            {
                SetProperty(ref _CodAngajat, value);
                OnPropertyChanged();
            }
        }
       
    }
}

using AppRammendoMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRammendoMobile.ViewModels
{
   public class JobSelectionViewModel:ViewModelBase
    {
       
        public ICommand CapiCommand { get; set; }
        public ICommand TelliCommand { get; set; }
        public JobSelectionViewModel()
        {
            CapiCommand = new Command(() => ExecuteCapiCommand());
            TelliCommand = new Command(() => ExecuteTelliCommand());
        }

        private async void ExecuteTelliCommand()
        {
           await Application.Current.MainPage.Navigation.PushModalAsync(new WorkPage());
        }

        private async void ExecuteCapiCommand()
        {
           await  Application.Current.MainPage.Navigation.PushModalAsync(new RepartoSelectionPage());
        }
    }
}

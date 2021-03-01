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

        private void ExecuteTelliCommand()
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new WorkPage());
        }

        private void ExecuteCapiCommand()
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new RepartoSelectionPage());
        }
    }
}

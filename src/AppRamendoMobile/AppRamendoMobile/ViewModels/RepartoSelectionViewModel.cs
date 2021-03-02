using AppRammendoMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRammendoMobile.ViewModels
{
   public class RepartoSelectionViewModel:ViewModelBase
    {
        public ICommand RepartoSelectionCommand 
        {
            get
            { return new Command<string>((reparto) => ExecuteRepartoSelectionCommand(reparto));
            } 
        }
        public RepartoSelectionViewModel()
        {
           
        }

        private  async void ExecuteRepartoSelectionCommand(string reparto)
        {
            //Application.Current.MainPage.DisplayAlert("Reparto","Reparto: " + reparto, "OK");
            await Application.Current.MainPage.Navigation.PushModalAsync(new WorkPage());
        }
    }
}

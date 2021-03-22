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
   public class RepartoSelectionViewModel:ViewModelBase
    {
        public ICommand RepartoSelectionCommand 
        {
            get
            { return new Command<string>(async(reparto) => await ExecuteRepartoSelectionCommand(reparto));
            } 
        }
        public RepartoSelectionViewModel()
        {
           
        }
        public RepartoSelectionViewModel(RammendoImport commessa, Angajati user)
        {
            Rammendo = commessa;
            User = user;
        }

        private  async Task ExecuteRepartoSelectionCommand(string reparto)
        {
            Reparto = reparto;
            Rammendo.Reparto = reparto;
            //Application.Current.MainPage.DisplayAlert("Reparto","Reparto: " + reparto, "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new WorkPage(Rammendo, User));
        }

       
       
    }
}

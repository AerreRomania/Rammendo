using AppRammendoMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRammendoMobile.ViewModels
{
   public class WorkPageViewModel:ViewModelBase
    {
        public ICommand InteractionButtonCommand
        {
            get
            {
                return new Command<string>((Condition) => ExecuteInterationButtonCommand(Condition));
            }
        }
        public WorkPageViewModel()
        {

        }
        public WorkPageViewModel( Angajati user,Commesse commessa, string reparto)
        {
            Commessa = commessa;
            User = user;
        }
        private void ExecuteInterationButtonCommand(string Condition)
        {
            if (int.TryParse(Condition, out var count))
            {
                count++;
                Counter = count;
                //Application.Current.MainPage.DisplayAlert("Counter!", "Counter: " + Counter.ToString(), "OK");
            }
            else
            {
                switch (Condition)
                {
                    case "Stop":
                        Application.Current.MainPage.DisplayAlert("STOP!", "STOP!", "OK");
                        break;
                    case "Scarti":
                        Application.Current.MainPage.DisplayAlert("Scarti!", "Scarti!", "OK");
                        break;
                    case "Pauza":
                        Application.Current.MainPage.DisplayAlert("Pauza!", "Pauza!", "OK");
                        break;
                }
            }
        }

      

    }
}

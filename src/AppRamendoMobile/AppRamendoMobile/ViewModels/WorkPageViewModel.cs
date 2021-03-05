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
   public class WorkPageViewModel:ViewModelBase
    {
        public ICommand InteractionButtonCommand
        {
            get
            {
                return new Command<string>(async (Condition) =>await ExecuteInterationButtonCommand(Condition));
            }
        }
        public ICommand EfficientaCommand { get; set; }
        public WorkPageViewModel()
        {
            EfficientaCommand = new Command(async () => await ExecuteEfficientaCommand());
        }
        public WorkPageViewModel( Angajati user,Commesse commessa, string reparto)
        {
            Commessa = commessa;
            User = user;
            EfficientaCommand = new Command(async() => await ExecuteEfficientaCommand());
        }

        private async Task ExecuteEfficientaCommand()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EfficientaPerOra());
        }

        private async Task ExecuteInterationButtonCommand(string Condition)
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
                       await Application.Current.MainPage.DisplayAlert("STOP!", "STOP!", "OK");
                        break;
                    case "Scarti":
                        await Application.Current.MainPage.Navigation.PushAsync(new ScartiConfirmationPage());
                        break;
                    case "Pauza":
                       await Application.Current.MainPage.DisplayAlert("Pauza!", "Pauza!", "OK");
                        break;
                }
            }
        }

      

    }
}

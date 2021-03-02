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

        private int _counter = 0;
        public int Counter
        {
            get => _counter;
            set
            {
                SetProperty(ref _counter, value);
                OnPropertyChanged();
            }
        }

        private Commesse _commessa;
        public Commesse Commessa
        {
            get=> _commessa;
            set
            {
                SetProperty(ref _commessa, value);
                OnPropertyChanged();
            }
        }

    }
}

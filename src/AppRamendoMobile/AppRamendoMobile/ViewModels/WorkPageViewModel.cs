using AppRammendoMobile.Models;
using AppRammendoMobile.Settings;
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
        public ICommand LogOutCommand { get; set; }
        public WorkPageViewModel()
        {
            EfficientaCommand = new Command(async () => await ExecuteEfficientaCommand());
            LogOutCommand = new Command(async () => await ExecuteLogOutCommand());
        }

       
        public WorkPageViewModel(RammendoImport commessa)
        {
            Rammendo = commessa;
            EfficientaCommand = new Command(async() => await ExecuteEfficientaCommand());
            LogOutCommand = new Command(async () => await ExecuteLogOutCommand());
        }
        private async Task ExecuteLogOutCommand()
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        private async Task ExecuteEfficientaCommand()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EfficientaPerOra());
        }

        private async Task ExecuteInterationButtonCommand(string Condition)
        {
            if (int.TryParse(Condition, out var count))
            {

                if (Rammendo.Diff > 0 || (Rammendo.Diff == 0 && Rammendo.GoodGood + Rammendo.BadBad < Rammendo.Bad))
                {
                    count++;
                    Counter = count;
                    Rammendo.GoodGood = Counter;
                    TotalQty++;
                    AppSettings.TotalQty = TotalQty;
                    await ApiClient.UpdateAsync<RammendoImport>(Rammendo, $"{Url}rammendoimport/1");
                    await ApiClient.InsertAsync<RammendoClicks>(new RammendoClicks() { Angajat = Rammendo.Angajat, ClickEvent = DateTime.Now, IdJob = Rammendo.Barcode, Quantity = 1, TypeOfWork = "Work" }, $"{Url}rammendoclicks");
                }
                //Application.Current.MainPage.DisplayAlert("Counter!", "Counter: " + Counter.ToString(), "OK");
            }
            else
            {
                switch (Condition)
                {
                    case "Stop":
                        {
                            bool result = await Application.Current.MainPage.DisplayAlert("Change Job?", "", "Yes", "No");
                            if (result) await Application.Current.MainPage.Navigation.PopAsync();
                            await ApiClient.InsertAsync<RammendoClicks>(new RammendoClicks() { Angajat = Rammendo.Angajat, ClickEvent = DateTime.Now, IdJob = Rammendo.Barcode, Quantity = 1, TypeOfWork = "Stop" }, $"{Url}rammendoclicks");
                        }
                        break;
                    case "Scarti":
                        await Application.Current.MainPage.Navigation.PushAsync(new ScartiConfirmationPage(Rammendo));
                        break;
                    case "Pauza":
                        await ApiClient.InsertAsync<RammendoClicks>(new RammendoClicks() { Angajat = Rammendo.Angajat, ClickEvent = DateTime.Now, IdJob = Rammendo.Barcode, Quantity = 1, TypeOfWork = "Pause" }, $"{Url}rammendoclicks");
                        break;
                }
            }
        }

      

    }
}

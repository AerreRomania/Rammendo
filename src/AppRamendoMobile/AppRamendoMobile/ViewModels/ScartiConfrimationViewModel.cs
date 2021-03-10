using AppRammendoMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRammendoMobile.ViewModels
{
    public class ScartiConfrimationViewModel:ViewModelBase
    {
        public ICommand ConfirmCommand { get; set; }
        public ScartiConfrimationViewModel()
        {
            ConfirmCommand = new Command(async () => await ExecuteConfirmCommand());
        }
        public ScartiConfrimationViewModel(RammendoImport rammendo)
        {
            Rammendo = rammendo;
            ConfirmCommand = new Command(async () => await ExecuteConfirmCommand());
        }
        private async Task ExecuteConfirmCommand()
        {
            try
            {
                if(ScartiFinal<=Rammendo.Bad)
                {
                    Rammendo.BadBad += ScartiFinal;
                    Rammendo.Diff = Rammendo.Bad - (Rammendo.GoodGood + Rammendo.BadBad);
                    await ApiClient.UpdateAsync<RammendoImport>(Rammendo, $"{Url}rammendoimport/1");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error !", "Scarti can't be bigger then Rammendare Quantity!", "Ok");
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
        }
    }
}

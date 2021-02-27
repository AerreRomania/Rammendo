using Rammendo.Services;
using Rammendo.Services.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Rammendo.ViewModels
{
    public class BaseViewModel {

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //private bool _isBusy;
        //public bool IsBusy {
        //    get => _isBusy;
        //    set {
        //        _isBusy = value;
        //        NotifyPropertyChanged("IsBusy");
        //    }
        //}

        public IApiService ApiService { get; set; }

        public BaseViewModel() {
            ApiService = new ApiService();
        }
    }
}

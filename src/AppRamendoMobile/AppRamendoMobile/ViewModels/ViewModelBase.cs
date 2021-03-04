using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppRammendoMobile.Services;
using Xamarin.Forms;

namespace AppRammendoMobile.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public ICameraScanner CameraScanner => DependencyService.Get<ICameraScanner>();
        public IApiClient ApiClient => DependencyService.Get<IApiClient>();
        public ILoginClient Loginclient => DependencyService.Get<ILoginClient>();

        public string Url => @"http://192.168.96.37:55388/api/";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}

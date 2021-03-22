using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppRammendoMobile.Models;
using AppRammendoMobile.Services;
using AppRammendoMobile.Settings;
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
        private bool _pauza=false;
        public bool Pauza
        {
            get => _pauza;
            set 
            { 
                SetProperty(ref _pauza, value);
                OnPropertyChanged();
            }
        }

        private string _reparto = string.Empty;
        public string Reparto
        {
            get => _reparto;
            set
            {
                SetProperty(ref _reparto, value);
                OnPropertyChanged();
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

        private Angajati _user;
        public Angajati User
        {
            get => _user;
            set
            {
                SetProperty(ref _user, value);
                OnPropertyChanged();
            }
        }

        private string _commessaString;
        public string CommessaString
        {
            get => _commessaString;
            set
            {
                SetProperty(ref _commessaString, value);
                OnPropertyChanged();
            }
        }

        private RammendoImport _commessa;
        public RammendoImport Rammendo
        {
            get => _commessa;
            set
            {
                SetProperty(ref _commessa, value);
                OnPropertyChanged();
            }
        }

        private string _telliString;
        public string TavoloString
        {
            get => _telliString;
            set
            {
                SetProperty(ref _telliString, value);
                OnPropertyChanged();
            }
        }

        private TelliProdoti _telli;
        public TelliProdoti Telli
        {
            get => _telli;
            set
            {
                SetProperty(ref _telli, value);
                OnPropertyChanged();
            }
        }

        private Efficiency _eff;
        public Efficiency Eff
        {
            get => _eff;
            set
            {
                SetProperty(ref _eff, value);
                OnPropertyChanged();
            }
        }

        private bool _isbusy = false;
        public bool IsBusy
        {
            get => _isbusy;
            set
            {
                SetProperty(ref _isbusy, value);
                OnPropertyChanged();
            }
        }

        private int _totalQty = AppSettings.TotalQty;
        public int TotalQty
        {
            get => _totalQty;
            set
            {
                SetProperty(ref _totalQty, value);
                OnPropertyChanged();
            }
        }
        private int _scartiFinal = 0;
        public int ScartiFinal
        {   
            get => _scartiFinal;
            set
            {
                SetProperty(ref _scartiFinal, value);
                OnPropertyChanged();
            }
        }
    }
}

using AppRammendoMobile.Models;
using AppRammendoMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRammendoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RepartoSelectionPage : ContentPage
    {

        
        public RepartoSelectionPage(Angajati user,Commesse Commessa)
        {
            InitializeComponent();
            BindingContext =  new RepartoSelectionViewModel(user, Commessa);
        }
    }
}
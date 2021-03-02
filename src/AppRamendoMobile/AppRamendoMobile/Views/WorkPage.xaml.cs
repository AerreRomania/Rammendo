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
    public partial class WorkPage : ContentPage
    {
        WorkPageViewModel vm;
        public WorkPage()
        {
            InitializeComponent();
            BindingContext = vm = new WorkPageViewModel();
        }
    }
}
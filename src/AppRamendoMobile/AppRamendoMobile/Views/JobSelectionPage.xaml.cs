﻿using AppRammendoMobile.Models;
using AppRammendoMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRammendoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobSelectionPage : ContentPage
    {
        public JobSelectionPage(Angajati angajati)
        {
            BindingContext = new JobSelectionViewModel(angajati);
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
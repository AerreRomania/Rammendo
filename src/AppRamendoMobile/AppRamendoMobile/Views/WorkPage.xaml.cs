﻿using AppRammendoMobile.Models;
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

        public WorkPage(RammendoImport commessa, Angajati user)
        {
            BindingContext = new WorkPageViewModel(commessa, user);
            InitializeComponent();
            
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
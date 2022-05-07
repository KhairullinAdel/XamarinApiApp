﻿using System;
using System.Collections.Generic;
using WeatherApiApp.Views;
using Xamarin.Forms;

namespace WeatherApiApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}

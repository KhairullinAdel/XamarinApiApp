using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApiApp.Models;

namespace WeatherApiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoListEditAndAddPage : ContentPage
    {
        bool IsNewItem;
        public ToDoListEditAndAddPage(bool isNew = false)
        {
            InitializeComponent();
            IsNewItem = isNew;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var todoItem = (Cat)BindingContext;
            await App.TodoManager.SaveCatAsync(todoItem, IsNewItem);
            await Navigation.PopAsync();
        }
        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var todoItem = (Cat)BindingContext;
            await App.TodoManager.DeleteCatAsync(todoItem);
            await Navigation.PopAsync();
        }
    }
}
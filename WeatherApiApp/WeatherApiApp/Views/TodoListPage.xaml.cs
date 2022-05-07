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
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TodoLV.ItemsSource = await App.TodoManager.GetCatItemModels();
        }

        private void TodoLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new ToDoListEditAndAddPage()
            {
                BindingContext = e.SelectedItem as Cat
            });
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ToDoListEditAndAddPage(true)
            {
                BindingContext = new Cat()
                {
                    Id = Guid.NewGuid().ToString(),
                }
            });
        }
    }
}
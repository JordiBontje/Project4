using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Models;
using App2.ViewModels;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2.Memento_Design_Pattern;

namespace App2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookmarksPage : ContentPage
	{
        BookmarksViewModel viewModel;
        public Originator originator = new Originator();
        public Caretaker caretaker = new Caretaker();
        int Startup = 0;
        Color buttoncolor;

        public BookmarksPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new BookmarksViewModel();
      
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            if (Startup != 0)
            {
                if (item.Favourite == 1)
                {
                    buttoncolor = Color.Gray;
                }
            }
            else
            {
                caretaker.mementoList.Add(new Memento(Color.Gray));
                Startup = 1;
                buttoncolor = Color.Gray;
            }

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item), buttoncolor, caretaker, originator));

            // Manually deselect item
            BookmarksListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();



            if (viewModel.Items.Count == 0)
            { 
                viewModel.LoadItemsCommand.Execute(null);
                BookmarksListView.ItemsSource = viewModel.Items.Where(i => i.Favourite == 1);
            }
            else
            {
                BookmarksListView.ItemsSource = viewModel.Items.Where(i => i.Favourite == 1);
            }
        }
    }
}
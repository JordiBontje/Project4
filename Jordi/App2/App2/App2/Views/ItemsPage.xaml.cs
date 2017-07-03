using System;

using App2.Models;
using App2.ViewModels;

using Xamarin.Forms;
using System.Linq;
using App2.Memento_Design_Pattern;

namespace App2.Views
{
	public partial class ItemsPage : ContentPage
	{
		ItemsViewModel viewModel;
        bool vegetarian = false;
        bool serves = false;
        bool Cook = false;
        public Originator originator = new Originator();
        public Caretaker caretaker = new Caretaker();
        int Startup = 0;
        Color buttoncolor;

        public ItemsPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new ItemsViewModel();
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
                    originator.getStateFromMemento(caretaker.get());
                    buttoncolor = originator.getState();
                }
                else
                {
                    buttoncolor = Color.White;
                }
            }
            else
            {
                caretaker.mementoList.Add(new Memento(Color.White));
                Startup = 1;
                buttoncolor = Color.White;
            }

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item), buttoncolor, caretaker, originator));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewItemPage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

            if (viewModel.Items.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);
		}
        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ItemsListView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                ItemsListView.ItemsSource = viewModel.Items;
            else
                ItemsListView.ItemsSource = viewModel.Items.Where(i => i.Title.ToLower().Contains(e.NewTextValue.ToLower()));

            ItemsListView.EndRefresh();

        }

        private void VegetarianClicked(object sender, EventArgs e)
        {
            ItemsListView.BeginRefresh();
            Button Button1 = this.FindByName<Button>("Button1");
            if (vegetarian == false)
            {
                vegetarian = true;
                ItemsListView.ItemsSource = viewModel.Items.Where(i => i.IsVegetarian == 1);
                Button1.BackgroundColor = Color.DarkGray;
                

            }
            else if(vegetarian == true)
            {
                vegetarian = false;
                ItemsListView.ItemsSource = viewModel.Items;
                Button1.BackgroundColor = Color.White;

            }
            ItemsListView.EndRefresh();
        }
        private void ServesClicked(object sender, EventArgs e)
        {
            ItemsListView.BeginRefresh();
            Button Button2 = this.FindByName<Button>("Button2");
            if (serves == false)
            {
                serves = true;
                ItemsListView.ItemsSource = viewModel.Items.Where(i => !i.Serves.ToLower().Contains("1") && !i.Serves.ToLower().Contains("2") && !i.Serves.ToLower().Contains("3") && !i.Serves.ToLower().Contains("4") && !i.Serves.ToLower().Contains("5") && !i.Serves.ToLower().Contains("6"));
                Button2.BackgroundColor = Color.DarkGray;


            }
            else if (serves == true)
            {
                serves = false;
                ItemsListView.ItemsSource = viewModel.Items;
                Button2.BackgroundColor = Color.White;

            }
            ItemsListView.EndRefresh();
        }
        private void CookClicked(object sender, EventArgs e)
        {
            ItemsListView.BeginRefresh();
            Button Button3 = this.FindByName<Button>("Button3");
            if (Cook == false)
            {
                Cook = true;
                ItemsListView.ItemsSource = viewModel.Items.Where(i => i.Cookinmin <= 30);
                Button3.BackgroundColor = Color.DarkGray;


            }
            else if (Cook == true)
            {
                Cook = false;
                ItemsListView.ItemsSource = viewModel.Items;
                Button3.BackgroundColor = Color.White;

            }
            ItemsListView.EndRefresh();
        }
    }

}

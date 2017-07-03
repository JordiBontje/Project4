using System;

using App2.Models;

using Xamarin.Forms;

namespace App2.Views
{
	public partial class NewItemPage : ContentPage
	{
		public Item Item { get; set; }

		public NewItemPage()
		{
			InitializeComponent();

			Item = new Item
			{
				Title = "Receipe Title",
                Ingredients = "All the Ingredients",
                Preptimemin = 0,
                Cookinmin = 0,
				Method = "The method for this Receipe"
			};

			BindingContext = this;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			MessagingCenter.Send(this, "AddItem", Item);
			await Navigation.PopToRootAsync();
		}
	}
}
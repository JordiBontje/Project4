
using App2.Memento_Design_Pattern;
using App2.ViewModels;
using System;
using Xamarin.Forms;

namespace App2.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public Originator originator;
        public Caretaker caretaker;


        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();
        }
        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

        }


        public ItemDetailPage(ItemDetailViewModel viewModel, Color buttoncolor, Caretaker caretaker, Originator originator)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            Button Button = this.FindByName<Button>("Favourite");
            Button.BackgroundColor = buttoncolor;
            this.caretaker = caretaker;
            this.originator = originator;
            
        }

        private void FavouriteClicked(object sender, EventArgs e)
        {
            Button Button = this.FindByName<Button>("Favourite");

            if (viewModel.Item.Favourite == 0)
            {

                viewModel.Item.Favourite = 1;
                Button.BackgroundColor = Color.Gray;
                originator.setState(Color.Gray);
                caretaker.add(originator.saveStateToMemento());
                
            }
            else
            {
                viewModel.Item.Favourite = 0;
                Button.BackgroundColor = Color.White;
                originator.setState(Color.White);
                caretaker.add(originator.saveStateToMemento());
            }
        }
    }
}
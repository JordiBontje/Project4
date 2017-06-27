using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class BookmarksViewModel : BaseViewModel
    {
        public BookmarksViewModel()
        {
            Title = "My Bookmarks";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
    }
}
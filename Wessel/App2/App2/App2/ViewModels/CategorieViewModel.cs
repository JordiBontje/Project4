using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class CategorieViewModel : BaseViewModel
    {
        public CategorieViewModel()
        {
            Title = "All Categories";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
    }
}
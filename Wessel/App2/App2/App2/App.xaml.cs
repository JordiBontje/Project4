using App2.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App2
{
	public partial class App : Application
	{
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

		public static void SetMainPage()
		{
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    //New navigatie menu item
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
                    },
                    //New navigatie menu item
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                    //New navigatie menu item
                    new NavigationPage(new CategoriePage())
                    {
                        Title = "Categories",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                    //New navigatie menu item
                    new NavigationPage(new BookmarksPage())
                    {
                        Title = "My Bookmarks",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                }
            };
        }
	}
}

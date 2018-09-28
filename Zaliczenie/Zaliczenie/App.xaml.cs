using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zaliczenie.Data;
using Zaliczenie.Models.Sqlite;
using Zaliczenie.Services;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Zaliczenie
{
	public partial class App : Application
	{
        private static LocalDB localDB;

        public static LocalDB LocalDB
        {
            get
            {
                if (localDB == null)
                {
                    var fileHelper = DependencyService.Get<IFileHelper>();
                    var fileName = fileHelper.GetLocalFilePath("AppDB.db3");
                    localDB = new LocalDB(fileName);
                    
                }
                return localDB;
            }
        }

		public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new FirstPage());
		}
        protected override void OnStart ()
		{
            // Handle when your app starts

        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

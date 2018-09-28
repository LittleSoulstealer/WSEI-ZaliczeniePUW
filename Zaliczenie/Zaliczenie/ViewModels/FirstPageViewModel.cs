using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Zaliczenie.Data;
using Zaliczenie.Models.Sqlite;
using Zaliczenie.Services;

namespace Zaliczenie.ViewModels
{
    public class FirstPageViewModel : BaseViewModel
    {
        public Command GoToMain { get; set; }
        public string Title { get; set; }


        public FirstPageViewModel() {


            Title = "Przelicznik kuchenny";

            GoToMain = new Command(() =>
            {
           
                Navigate();


            });

}

        async private void Navigate()
        {
            await NavigationService.NavigateTo(new  MainPage());
        }
    }
}

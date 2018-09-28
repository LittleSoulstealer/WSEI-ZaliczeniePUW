using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zaliczenie.ViewModels;

namespace Zaliczenie
{
	
	public partial class FirstPage : ContentPage
	{
		public FirstPage ()
		{
           
            InitializeComponent ();
            BindingContext = new FirstPageViewModel();
        }
	}
}
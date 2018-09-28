using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Zaliczenie.Data;
using Zaliczenie.Models.Sqlite;

namespace Zaliczenie.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Result { get; set; }
        public List<Products> ListOfProducts { get; set; }
        public LocalDB DB { get; set; }
        public Command ConvertButton {get; set;}
        public string EntryText { get; set; }
        public Products Item { get; set; }
        public int Index { get; set; }





        public MainPageViewModel()
        {
            DB = App.LocalDB;
            Title = "Przelicznik kuchenny";
            ListOfProducts = new List<Products>();
            GetListFromDBAsync();
            RaisePropertyChanged(nameof(ListOfProducts));

            Index = -1;


            ConvertButton = new Command(() =>
            {
                int Amount = 0;

               

                if (Index < 0)
                {
                    Result = "Nie wybrano produktu!";
                    RaisePropertyChanged(nameof(Result));
                }
                else
                {

                    if (Int32.TryParse(EntryText, out Amount))
                    {
                        int Cups = 0;

                        Cups = Amount / Item.Cup;


                        Amount = Amount - (Cups * Item.Cup);

                        int BSpoons = Amount / Item.BSpoon;
                        Amount = Amount - (BSpoons * Item.BSpoon);

                        float SSpoons = (float)Amount / (float)Item.SSpoon;


                        Result = EntryText + "g to " + Cups.ToString() + " szklanki, " + BSpoons.ToString() + " łyżki i " + SSpoons.ToString("0.00") + " łyżeczki.";
                        RaisePropertyChanged(nameof(Result));
                    }
                    else
                    {
                        Result = "Przelicznik przyjmuje tylko pełne gramy.";
                        RaisePropertyChanged(nameof(Result));
                    }
                }
            });

        }

        public async void GetListFromDBAsync()
        {
            List<Products> BaseProducts = new List<Products>();
            Products product1 = new Products() { Name = "rodzynki", ID = 1, Cup = 140, BSpoon = 15, SSpoon = 7 };
            Products product2 = new Products() { Name = "mąka", ID = 2, Cup = 180, BSpoon = 17, SSpoon=8};
            BaseProducts.Add(product1);
            BaseProducts.Add(product2);
            BaseProducts.ForEach(async delegate (Products p) {
                await DB.SaveItemAsync(p);
            });
          ListOfProducts = await DB.GetItems<Products>();
           RaisePropertyChanged(nameof(ListOfProducts));
        }


        
        }
}

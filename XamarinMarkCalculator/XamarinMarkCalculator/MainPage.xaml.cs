using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinMarkCalculator
{
    public partial class MainPage : ContentPage
    {
        private StudentBook studentBook;

        public MainPage()
        {
            InitializeComponent();

            Task.Run(async () =>
           {
               this.studentBook = new StudentBook(await SQLAction.CreateAsync("database.db"));
               // schování activity indicatoru (+ zablokování)
           });
        }

        private async void NewButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewPage(this.studentBook));
        }
    }
}

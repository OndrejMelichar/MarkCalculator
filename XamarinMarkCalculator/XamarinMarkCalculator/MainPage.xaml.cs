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
        public MainPage()
        {
            InitializeComponent();
        }

        private async void NewButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewPage());
        }
    }
}

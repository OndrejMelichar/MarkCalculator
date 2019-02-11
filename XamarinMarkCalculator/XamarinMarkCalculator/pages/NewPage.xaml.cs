using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMarkCalculator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPage : ContentPage
	{
        private StudentBook studentBook;

        public NewPage (StudentBook studentBook)
		{
			InitializeComponent();
            this.studentBook = studentBook;
		}

        private async void NewSubjectButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewSubjectPage(this.studentBook));
        }

        private async void NewMarkButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewMarkPage());
            Navigation.RemovePage(this);
            //Navigation.PopAsync();
        }
    }
}
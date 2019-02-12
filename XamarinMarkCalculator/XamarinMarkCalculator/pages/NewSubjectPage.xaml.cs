using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMarkCalculator.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewSubjectPage : ContentPage
	{
        private StudentBook studentBook;
        private StackLayout mainStackLayout;
        private MainPage mainPage;


        public NewSubjectPage (StudentBook studentBook, StackLayout mainStackLayout, MainPage mainPage)
		{
			InitializeComponent();
            this.studentBook = studentBook;
            this.mainStackLayout = mainStackLayout;
            this.mainPage = mainPage;

        }

        private async void NewSubjectNameButtonClicked(object sender, EventArgs e)
        {
            string newSubjectName = newSubjectNameEntry.Text;

            this.studentBook.AddSubject(newSubjectName);
            this.mainPage.AddSubjectButton(newSubjectName);
            this.mainPage.UpdateNewSubjectButton();
            await this.Navigation.PopModalAsync();

        }
    }
}
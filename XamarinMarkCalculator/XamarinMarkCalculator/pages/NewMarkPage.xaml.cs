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
	public partial class NewMarkPage : ContentPage
	{
        private Subject subject;
        private int index;
        private StudentBook studentBook;
        private StackLayout mainStackLayout;
        private SubjectMarksPage subjectMarksPage;

        public NewMarkPage(Subject subject, int index, StudentBook studentBook, StackLayout mainStackLayout, SubjectMarksPage subjectMarksPage)
        {
            InitializeComponent();

            this.subject = subject;
            this.index = index;
            this.studentBook = studentBook;
            this.mainStackLayout = mainStackLayout;
            this.subjectMarksPage = subjectMarksPage;
        }

        private async void NewMarkButtonClicked(object sender, EventArgs e)
        {
            float newMarkValue;
            int newMarkWeight;
            bool parse1 = float.TryParse(newMarkValueEntry.Text, out newMarkValue);
            bool parse2 = int.TryParse(newMarkWeightEntry.Text, out newMarkWeight);

            if (parse1 && parse2 && this.newMarkValueCheck(newMarkValue))
            {
                this.studentBook.AddMark(newMarkValue, newMarkWeight, this.subject);
                this.subjectMarksPage.AddMark(newMarkValue, newMarkWeight);
                ((Label)((StackLayout)this.mainStackLayout.Children[this.index]).Children[1]).Text = this.studentBook.GetMarksAverage(this.studentBook.MarksBySubjects[this.index]).ToString();
                this.subjectMarksPage.UpdateNewMarkButton();
                await this.Navigation.PopModalAsync();
            }
        }

        private bool newMarkValueCheck(float mark)
        {
            if (mark == 1f || mark == 1.5f || mark == 2f || mark == 2.5f || mark == 3f || mark == 3.5f || mark == 4f || mark == 4.5f || mark == 5f)
            {
                return true;
            }

            return false;
        }
    }
}
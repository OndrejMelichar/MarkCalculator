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
	public partial class SubjectMarksPage : ContentPage
	{
        private Subject subject;
        private int index;
        private StudentBook studentBook;
        private StackLayout mainStackLayout;

        public SubjectMarksPage(Subject subject, int index, StudentBook studentBook, StackLayout mainStackLayout)
        {
            InitializeComponent();

            this.subject = subject;
            this.index = index;
            this.studentBook = studentBook;
            this.mainStackLayout = mainStackLayout;

            this.ShowMarks();
        }

        private void ShowMarks()
        {
            for (int i = 0; i < this.studentBook.MarksBySubjects[this.index].Count; i++)
            {
                Mark mark = this.studentBook.MarksBySubjects[this.index][i];
                this.AddMark(mark.Value, mark.Weight);
            }

            this.UpdateNewMarkButton(false);
        }

        public void AddMark(float value, int weight)
        {
            string labelText = value.ToString() + " (" + weight.ToString() + ")";
            marksStackLayout.Children.Add(new Label() { Text = labelText });
        }

        public void UpdateNewMarkButton(bool removeOld = true)
        {
            if (removeOld && marksStackLayout.Children.Count >= 2)
            {
                marksStackLayout.Children.RemoveAt(marksStackLayout.Children.Count - 2);
            }

            Button newSubjectButton = new Button() { Text = "Přidat známku" };
            newSubjectButton.Clicked += this.newMarkButtonClicked;
            marksStackLayout.Children.Add(newSubjectButton);
        }

        private async void newMarkButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewMarkPage(this.studentBook.Subjects[index], this.index, this.studentBook, this.mainStackLayout, this));
        }

    }
}
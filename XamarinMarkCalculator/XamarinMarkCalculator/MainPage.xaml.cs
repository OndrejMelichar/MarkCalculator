using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMarkCalculator.pages;

namespace XamarinMarkCalculator
{
    public partial class MainPage : ContentPage
    {
        private StudentBook studentBook;

        public MainPage()
        {
            InitializeComponent();

            this.x();
        }

        private async Task x()
        {
            await Task.Run(async () =>
            {
                this.studentBook = new StudentBook(await SQLAction.CreateAsync("database.db"));
                // schování activity indicatoru (+ zablokování)
            }).ConfigureAwait(true); // je potřeba configuje await? (s false to asi nefunguje)


            for ( int i = 0; i < this.studentBook.MarksBySubjects.Count; i++)
            {
                List<Mark> subjectMarks = this.studentBook.MarksBySubjects[i];
                float average = this.studentBook.GetMarksAverage(subjectMarks);

                StackLayout subjectRowStackLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
                Label subjectNameLabel = new Label() { Text = this.studentBook.Subjects[i].Name };
                Label averageLabel = new Label() { Text = average.ToString() };

                subjectRowStackLayout.Children.Add(subjectNameLabel);
                subjectRowStackLayout.Children.Add(averageLabel);
                mainStackLayout.Children.Add(subjectRowStackLayout);
            }

            Button newSubjectButton = new Button() { Text = "Přidat předmět" };
            newSubjectButton.Clicked += this.newSubjectButtonClicked;

            mainStackLayout.Children.Add(newSubjectButton);

        }

        private async void newSubjectButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewSubjectPage(this.studentBook, mainStackLayout, this));
        }

        public async void subjectButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SubjectMarksPage());
        }
    }
}

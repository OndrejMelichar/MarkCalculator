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

            this.Start();
        }

        private async Task Start()
        {
            await Task.Run(async () =>
            {
                this.studentBook = new StudentBook(await SQLAction.CreateAsync("database.db"));
                // schování activity indicatoru (+ zablokování)
            }).ConfigureAwait(true); // je potřeba configuje await? (s false to asi nefunguje)


            for (int i = 0; i < this.studentBook.MarksBySubjects.Count; i++)
            {
                List<Mark> subjectMarks = this.studentBook.MarksBySubjects[i];
                float average = this.studentBook.GetMarksAverage(subjectMarks);
                this.AddSubjectRow(this.studentBook.Subjects[i].Name, average);
            }

            this.UpdateNewSubjectButton(false);

        }

        public void AddSubjectRow(string newSubjectName, float average = 0f)
        {
            StackLayout subjectRowStackLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            Button newSubjectButton = new Button() { Text = newSubjectName};
            Label averageLabel = new Label() { Text = average.ToString() };
            
            subjectRowStackLayout.Children.Add(newSubjectButton);
            subjectRowStackLayout.Children.Add(averageLabel);
            mainStackLayout.Children.Add(subjectRowStackLayout);

            newSubjectButton.Clicked += subjectButtonClicked;
        }

        public void UpdateNewSubjectButton(bool removeOld = true)
        {
            if (removeOld && mainStackLayout.Children.Count >= 2)
            {
                mainStackLayout.Children.RemoveAt(mainStackLayout.Children.Count - 2);
            }

            Button newSubjectButton = new Button() { Text = "Přidat předmět" };
            newSubjectButton.Clicked += this.newSubjectButtonClicked;
            mainStackLayout.Children.Add(newSubjectButton);
        }

        private int containsChildren(StackLayout stackLayout, object sender)
        {
            var list = stackLayout.Children;
            Button senderButton = (Button)sender;

            for (int i = 0; i < list.Count; i++)
            {
                string listButtonText = ((Button)(((StackLayout)list[i]).Children[0])).Text;

                if (listButtonText.Equals(senderButton.Text))
                {
                    return i;
                }
            }

            return -1;
        }

        private async void newSubjectButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewSubjectPage(this.studentBook, mainStackLayout, this));
        }

        public async void subjectButtonClicked(object sender, EventArgs e)
        {
            int index = this.containsChildren(mainStackLayout, sender);

            await Navigation.PushModalAsync(new SubjectMarksPage(this.studentBook.Subjects[index], index, this.studentBook, mainStackLayout));
        }
        
    }
}

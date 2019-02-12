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

            x();
        }

        private async Task x()
        {
            await Task.Run(async () =>
            {
                this.studentBook = new StudentBook(await SQLAction.CreateAsync("database.db"));
                // schování activity indicatoru (+ zablokování)
            }).ConfigureAwait(true); // je potřeba configuje await? (s false to asi nefunguje)

            //další kód (UI) zde:
            foreach (List<Mark> subjectMakrs in this.studentBook.MarksBySubjects)
            {
                float average = this.studentBook.GetMarksAverage(subjectMakrs);

                StackLayout subjectRowStackLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
                subjectRowStackLayout.Children.Add(new Label() { Text = "předmět" });
                subjectRowStackLayout.Children.Add(new Label() { Text = average.ToString() });
                MainStackLayout.Children.Add(subjectRowStackLayout);
            }

        }
    }
}

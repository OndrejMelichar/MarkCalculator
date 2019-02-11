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
	public partial class NewSubjectPage : ContentPage
	{
        private StudentBook studentBook;

        public NewSubjectPage ()
		{
			InitializeComponent();
            this.studentBook = new StudentBook();
        }

        private void NewSubjectConfirmButtonClicked(object sender, EventArgs e)
        {
            string subjectName = NewSubjectEntry.Text;

            if (!this.studentBook.SubjectNameExists(subjectName.ToLower()))
            {
                this.studentBook.AddSubject(subjectName);
                Navigation.RemovePage(this);
            }
            else
            {
                //* tento předmět již existuje
            }

            //* přesměrování domů (aktualizace výpisu?)
        }
    }
}
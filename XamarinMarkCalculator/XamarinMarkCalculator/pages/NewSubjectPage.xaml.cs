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
		public NewSubjectPage ()
		{
			InitializeComponent ();
		}

        private void NewSubjectConfirmButtonClicked(object sender, EventArgs e)
        {
            //přesměrování domů (aktualizace výpisu?)
        }
    }
}
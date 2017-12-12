using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xenarthra.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Informacao : ContentPage
	{
		public Informacao ()
		{
			InitializeComponent ();
		}

        private void txCellSobre_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InformacaoDetalhada(1));
        }

        private void txCellXenarthras_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InformacaoDetalhada(2));
        }
    }
}

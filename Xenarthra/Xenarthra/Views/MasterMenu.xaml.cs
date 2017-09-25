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
	public partial class MasterMenu : ContentPage
	{
		public MasterMenu ()
		{
			InitializeComponent ();
            this.BackgroundColor = new Color(255, 255, 255, 0.5);
		}

        public void btnMapa()
        {
            DisplayAlert("teste", "teste", "ok");
        }

        private void vcMapa_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("apertado", "foi doido", "ok");
        }
    }
}

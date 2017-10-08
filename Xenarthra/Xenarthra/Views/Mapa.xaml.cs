using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Xenarthra.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mapa : ContentPage
	{        
        public Mapa ()
		{            
            InitializeComponent ();
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(-6.283629, -79.169832), Distance.FromKilometers(5300))
                );            
            
        }

        private void btnFiltrar_Clicked(object sender, EventArgs e)
        {
           // AnimaisPicker.IsVisible = true;
            AnimaisPicker.Focus();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xenarthra.Views;
namespace Xenarthra
{
	public partial class Login : ContentPage
	{
		public Login()
		{
			InitializeComponent();
            BackgroundImage = "background.png";
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = (new MasterDetail());
        }
    }
}

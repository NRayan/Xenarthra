using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xenarthra.Models;

namespace Xenarthra.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetail : MasterDetailPage
	{
        public MasterDetail (Usuario usu)
		{
			InitializeComponent ();
            this.Master = new MasterMenu(this,usu);
            this.Detail = new NavigationPage(new Mapa());
		}
	}
}

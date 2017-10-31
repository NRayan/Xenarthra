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
	public partial class Aparicao_Envio : ContentPage
	{
        public Aparicao_Envio ()
		{
			InitializeComponent ();

            
		}

        public Aparicao_Envio(ImageSource img)
        {
            InitializeComponent();
            imgAparicao.Source = img;
        }
    }
}

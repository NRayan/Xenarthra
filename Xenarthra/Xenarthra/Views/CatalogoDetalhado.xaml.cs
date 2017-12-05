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
	public partial class CatalogoDetalhado : ContentPage
	{
		public CatalogoDetalhado (Animal ani)
		{
			InitializeComponent ();
            lblNomeAnimal.Text = ani.ani_Nome;
            lblNomeCientifico.Text = ani.ani_NomeCient;
            lblDescricaoAnimal.Text = ani.ani_Descricao;
		}
	}
}

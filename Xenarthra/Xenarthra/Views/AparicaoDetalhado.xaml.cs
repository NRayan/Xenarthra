using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xenarthra.DataService;
using Xenarthra.Models.extra;

namespace Xenarthra.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AparicaoDetalhado : TabbedPage
	{
        AparicaoService apaService = new AparicaoService();
        public AparicaoDetalhado()
        {
            InitializeComponent();
        }

        public AparicaoDetalhado(int apa_ID)
        {
            InitializeComponent();
            BuscarAparicao(apa_ID);            
        }

        private async void BuscarAparicao(int apa_ID)
        {
            Aparicao_Extended _apar = await apaService.BuscarAparicao(apa_ID);
            lblAnimal.Text = _apar.ani_Nome;
            lblComentario.Text = _apar.apa_Comentario;
            lblComentarioADM.Text = _apar.apa_ComentarioADM;
            lblData.Text = _apar.apa_Data.ToShortDateString();
            lblNomeUsuario.Text = _apar.usu_Nome;
        }
    }
}

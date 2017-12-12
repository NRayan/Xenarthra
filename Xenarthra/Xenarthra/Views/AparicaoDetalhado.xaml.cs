using System;
using System.Collections.Generic;
using System.IO;
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


            imgUsuario.Source = ImageSource.FromStream(() => new MemoryStream(StringToByteArray(_apar.usu_IMG)));
            imgAparicao.Source = ImageSource.FromStream(() => new MemoryStream(StringToByteArray(_apar.apa_IMG)));
        }

        public static byte[] StringToByteArray(String hex)//String Hexadecimal para ByteArray 
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xenarthra.DataService;
using Xenarthra.Models;

namespace Xenarthra.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CatalogoDetalhado : ContentPage
	{
		public CatalogoDetalhado (int ani_id)
		{
            InitializeComponent();
            BuscarAni(ani_id);			
        }

        private async void BuscarAni(int id)
        {
            AnimalService _AniService = new AnimalService();
            Animal ani = await _AniService.BuscarAnimal(id);

            lblNomeAnimal.Text = ani.ani_Nome;
            lblNomeCientifico.Text = ani.ani_NomeCient;
            lblDescricaoAnimal.Text = ani.ani_Descricao;
            imgAnimal.Source = ImageSource.FromStream(() => new MemoryStream(StringToByteArray(ani.ani_IMG)));
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

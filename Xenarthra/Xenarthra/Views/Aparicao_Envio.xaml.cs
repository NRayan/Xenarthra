using System;
using System.Collections.Generic;
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
	public partial class Aparicao_Envio : ContentPage
	{
        public int usu_ID { get; set; }

        public Aparicao_Envio(ImageSource img, int usu_id)
        {
            InitializeComponent();
            imgAparicao.Source = img;
            usu_ID = usu_id;
        }

        private async void btnSend_Clicked(object sender, EventArgs e)
        {
            AparicaoService apaService = new AparicaoService();
            Aparicao apa = new Aparicao();

            apa.apa_Comentario = txtComentario.Text;
            apa.apa_Data = txtData.Date;
            apa.apa_Latitude = Convert.ToDecimal(txtLatitude.Text);
            apa.apa_Longitude = Convert.ToDecimal(txtLongitude.Text);
            apa.apa_ID_USU = usu_ID;
            apa.apa_ID_ANI = 1; //animal Indefinido
            apa.apa_status = 1; // status = pendente

            if (await apaService.CadastrarAparicao(apa) == true)
            {
                await DisplayAlert("", "Aparicao Enviada com Sucesso", "OK");
                await this.Navigation.PopToRootAsync();
            }else
            {
                await DisplayAlert("Erro", "Erro ao Enviar Aparicao", "OK");
            }
        }
    }
}

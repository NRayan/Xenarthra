using Plugin.Geolocator;
using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xenarthra.DataService;
using Xenarthra.Models;

namespace Xenarthra.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Aparicao_Envio : ContentPage
	{
        private int usu_ID;
        private byte[] imageBytes;

        public Aparicao_Envio(ImageSource img,byte[] imgBytes,int usu_id)
        {
            InitializeComponent();
            imgAparicao.Source = img;
            usu_ID = usu_id;
            imageBytes = imgBytes;
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
            apa.apa_IMG = ByteArrayToString(imageBytes);

            if (await apaService.CadastrarAparicao(apa) == true)
            {
                await DisplayAlert("", "Aparicao Enviada com Sucesso", "OK");
                await this.Navigation.PopToRootAsync();
            }else
            {
                await DisplayAlert("Erro", "Erro ao Enviar Aparicao", "OK");
            }
        }
        private void btnCapturarLatLong_Clicked(object sender, EventArgs e)
        {
            CapturarLatLong();
        }
        public static string ByteArrayToString(byte[] ba) //ByteArray para String Hexadecimal
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private async void CapturarLatLong()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(timeout: TimeSpan.FromSeconds(10));

                txtLatitude.Text = position.Latitude.ToString();
                txtLongitude.Text = position.Longitude.ToString();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.ToString(), "OK");
                throw;
            }
        }

    
    }
}

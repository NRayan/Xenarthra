using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xenarthra.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AparicaoView : ContentPage
    {
        public ImageSource imgEnvio { get; set; }//Imagem passada para a View Aparicao_Envio
        public int usu_ID { get; set; }


        public AparicaoView(int usu_id)
        {
            InitializeComponent();
            usu_ID = usu_id;
        }

        //imagem usada na captura
        byte[] img = null;
        protected Image _photo;

        //Conversor Imagem -> Bytes
        public byte[] ReadFully(Stream Imput)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = Imput.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }

        }

        private void btnCapturar_Clicked(object sender, EventArgs e)
        {
            capturarGaleria();
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            if (imgAparicao.Source != null)
            {
                imgAparicao.Source = null;
                Navigation.PushAsync(new Aparicao_Envio(imgEnvio,img,usu_ID));
            }
            else
                DisplayAlert("Atenção", "Insira uma imagem para Envio", "Ok");
        }      

        private async void capturarGaleria()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Indísponível", "Recurso indisponível", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                });

                if (file == null)
                {
                    return;
                }

                img = ReadFully(file.GetStream());
                imgAparicao.Source = ImageSource.FromStream(() => file.GetStream());
                imgEnvio = ImageSource.FromStream(() => file.GetStream());
            }

            catch (Exception ex)
            {
                await this.DisplayAlert("Erro", "Problema ao Executar ação", "ok");
            }
        }


    }
}

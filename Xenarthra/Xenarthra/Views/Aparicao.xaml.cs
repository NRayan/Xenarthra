using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xenarthra.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Aparicao : ContentPage
	{
        public Aparicao ()
		{
			InitializeComponent ();
		}
        //imagem usada na captura
        byte[] img = null;

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
        private async void btnImgFromGallery_Clicked(object sender, EventArgs e)
        {
            capturarGaleria();
        }

        private async void btnImgFromCamera_Clicked(object sender, EventArgs e)
        {
            capturarCamera();
        }

        private async void capturarCamera()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Sem Camera", "Recurso indisponível", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    AllowCropping = true,
                    SaveToAlbum = true,
                    Name = "capXen.jpg"
                });

                if (file == null)
                {
                    return;
                }

                img = ReadFully(file.GetStream());
                imgAparicao.Source = ImageSource.FromStream(() => file.GetStream());
                imgAparicao.IsVisible = true;
            }

            catch (Exception ex)
            {
                await this.DisplayAlert("Erro", "Problema ao Executar ação", "ok");
            }
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
                imgAparicao.IsVisible = true;
            }

            catch (Exception ex)
            {
                await this.DisplayAlert("Erro", "Problema ao Executar ação", "ok");
            }
        }
    }
}

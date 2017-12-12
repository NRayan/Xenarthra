using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void btnImagem_Tapped(object sender, EventArgs e)
        {
            pickerImagem.Focus();
        }

        private void pickerImagem_Unfocused(object sender, FocusEventArgs e)
        {
            if (pickerImagem.SelectedIndex == 0)
            {
                capturarCamera();
            }
            else if(pickerImagem.SelectedIndex == 1)
            {
                capturarGaleria();
            }
        }

        private void pickerImagem_Focused(object sender, FocusEventArgs e)
        {
            pickerImagem.SelectedItem = -1;
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
                imgPerfil.Source = ImageSource.FromStream(() => file.GetStream());
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
                imgPerfil.Source = ImageSource.FromStream(() => file.GetStream());
            }

            catch (Exception ex)
            {
                await this.DisplayAlert("Erro", "Problema ao Executar ação", "ok");
            }
        }

        private void btnConfirmar_Clicked(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();           

            usu.usu_Nome = txtNome.Text;
            usu.usu_Email = txtEmail.Text;
            usu.usu_Senha = txtSenha.Text;
            usu.usu_ADM = false;
            // usu.usu_IMG = ;

            CadastrarUsuario(usu);
        }

        private async void CadastrarUsuario(Usuario usu)
        {
            UsuarioService usuService = new UsuarioService();

            if (await usuService.CadastrarUsuario (usu) == true)
            {
                await DisplayAlert(" ", "Usuário Cadastrado com Sucesso", "Ok");
                txtEmail.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtSenha.Text = string.Empty;
            }                
            else
                await DisplayAlert("Erro", "Erro ao cadastrar Usuário", "Ok");
        }

    }
}

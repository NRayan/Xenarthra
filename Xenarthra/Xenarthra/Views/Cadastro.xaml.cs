using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        string imgUsuario;
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
            else if (pickerImagem.SelectedIndex == 1)
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
                imgUsuario = ByteArrayToStr(img);
                imgPerfil.Source = ImageSource.FromStream(() => file.GetStream());
            }

            catch (Exception ex)
            {
                await this.DisplayAlert("Erro", "Problema ao Executar ação", "ok");
            }
        }

        private void btnConfirmar_Clicked(object sender, EventArgs e)
        {
            if (imgUsuario != null)
            {
                if (txtEmail.Text != null & txtNome.Text != null & txtSenha.Text != null)
                {
                    Usuario usu = new Usuario();
                    usu.usu_Nome = txtNome.Text;
                    usu.usu_Email = txtEmail.Text;
                    usu.usu_Senha = hashmd5(txtSenha.Text);
                    usu.usu_ADM = false;
                    //usu.usu_IMG = imgUsuario;
                    CadastrarUsuario(usu);
                }
                else
                    DisplayAlert("Erro", "Preencha Todos os Campos", "OK");




            }
            else
                DisplayAlert("Erro", "Insira uma Imagem de Perfil", "OK");
        }

        private string hashmd5(string str)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(str);
            byte[] hash = md5.ComputeHash(inputBytes);


            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private string ByteArrayToStr(Byte[] img) // Byte[] -> String
        {
            return Encoding.ASCII.GetString(img);
        }

        private Byte[] StrToByteArray(string str)// String -> Byte[]
        {
            return Encoding.ASCII.GetBytes(str);
        }



        private async void CadastrarUsuario(Usuario usu)
        {
            UsuarioService usuService = new UsuarioService();

            if (await usuService.CadastrarUsuario(usu) == true)
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

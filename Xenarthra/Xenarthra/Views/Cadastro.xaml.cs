using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
            capturarGaleria();
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
                    PhotoSize = PhotoSize.Small,
                    CompressionQuality = 50
                });

                if (file == null)
                {
                    return;
                }
                imgPerfil.Source = ImageSource.FromStream(() => file.GetStream());


                img = ReadFully(file.GetStream());
                imgUsuario = ByteArrayToString(img);

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
                    usu.usu_IMG = imgUsuario;
                    CadastrarUsuario(usu);
                }
                else
                    DisplayAlert("Atenção", "Preencha Todos os Campos", "OK");
            }
            else
                DisplayAlert("Atenção", "Insira uma Imagem de Perfil", "OK");
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
                imgPerfil.Source = "profile.png";
                imgUsuario = string.Empty;
            }
            else
                await DisplayAlert("Erro", "Erro ao cadastrar Usuário", "Ok");
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

        public static string ByteArrayToString(byte[] ba) //ByteArray para String Hexadecimal
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
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

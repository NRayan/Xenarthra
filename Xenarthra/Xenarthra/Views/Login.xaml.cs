using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xenarthra.Views;
using Xenarthra.DataService;
using Xenarthra.Models;
using System.Security.Cryptography;

namespace Xenarthra
{
	public partial class Login : ContentPage
	{
        UsuarioService UsuService = new UsuarioService();

		public Login()
		{
			InitializeComponent();
		}       

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            Logar(txtEmail.Text, hashmd5(txtSenha.Text));
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro());
        }

        private async void Logar(string email,string senha)
        {
            if (await UsuService.ValidarUsuario(email,senha) == true)
            {
                Usuario _usu = await UsuService.BuscarUsuarioporEmail(email);
                App.Current.MainPage = (new MasterDetail(_usu));
            }
                
            else
                await DisplayAlert("Erro", "Email Ou Senha Inválidos", "Ok");
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

    }
}

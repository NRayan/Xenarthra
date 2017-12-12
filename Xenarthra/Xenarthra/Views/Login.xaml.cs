using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xenarthra.Views;
using Xenarthra.DataService;
using Xenarthra.Models;

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
            Logar(txtEmail.Text, txtSenha.Text);
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro());
        }

        private async void Logar(string email,string senha)
        {
            if (await UsuService.ValidarUsuario(email,senha) == true)
                App.Current.MainPage = (new MasterDetail());
            else
                await DisplayAlert("Erro", "Email Ou Senha Inválidos", "Ok");
        }

    }
}

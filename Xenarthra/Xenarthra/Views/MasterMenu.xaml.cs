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
using Xenarthra.Models;

namespace Xenarthra.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenu : ContentPage
    {
        public MasterDetailPage mdpView { get; set; }
        public int _usuLocal { get; set; }

        public MasterMenu(MasterDetailPage objMDP,Usuario usuLocal )
        {
            mdpView = objMDP;          
            InitializeComponent();
            lblUsuario.Text = usuLocal.usu_Nome;

            _usuLocal = usuLocal.usu_ID;    
           // imgPefil.Source= ImageSource.FromStream(() => new MemoryStream( StrToByteArray(usuLocal.usu_IMG))); // Conversor Byte[] -> ImagemSource
            imgPefil.Source = "perfil.png";
        }

        private void vcMapa_Tapped(object sender, EventArgs e)
        {
            mdpView.Detail = new NavigationPage(new Mapa());
            mdpView.IsPresented = false;
        }

        private void vcCatalogo_Tapped(object sender, EventArgs e)
        {
            mdpView.Detail = new NavigationPage(new Catalogo());
            mdpView.IsPresented = false;
        }

        private void vcImagem_Tapped(object sender, EventArgs e)
        {
            mdpView.Detail = new NavigationPage(new AparicaoView(_usuLocal));
            mdpView.IsPresented = false;
        }

        private void vcInfo_Tapped(object sender, EventArgs e)
        {
            mdpView.Detail = new NavigationPage(new Informacao());
            mdpView.IsPresented = false;
        }

        private string ByteArrayToStr(Byte[] img) // Byte[] -> String
        {
            return Encoding.ASCII.GetString(img);
        }

        private Byte[] StrToByteArray(string str)// String -> Byte[]
        {
            return Encoding.ASCII.GetBytes(str);
        }
    }
}

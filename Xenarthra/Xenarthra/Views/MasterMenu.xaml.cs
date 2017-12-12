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
        public ImageSource imgSource { get; set; }


        private Byte[] imgConvertida;
       

        public MasterMenu(MasterDetailPage objMDP,Usuario usuLocal )
        {
            mdpView = objMDP;          
            InitializeComponent();
            lblUsuario.Text = usuLocal.usu_Nome;
            _usuLocal = usuLocal.usu_ID;

            imgConvertida = (StringToByteArray(usuLocal.usu_IMG));
            imgPefil.Source = ImageSource.FromStream(() => new MemoryStream(imgConvertida));
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

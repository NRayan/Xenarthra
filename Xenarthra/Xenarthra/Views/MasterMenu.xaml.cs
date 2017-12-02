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

namespace Xenarthra.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenu : ContentPage
    {
        public MasterDetailPage mdpView { get; set; }
        public MasterMenu()
        {
            InitializeComponent();
        }

        public MasterMenu(MasterDetailPage objMDP)
        {
            mdpView = objMDP;
            InitializeComponent();
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
            mdpView.Detail = new NavigationPage(new Aparicao());
            mdpView.IsPresented = false;
        }

        private void vcInfo_Tapped(object sender, EventArgs e)
        {
            mdpView.Detail = new NavigationPage(new Informacao());
            mdpView.IsPresented = false;
        }
    }
}

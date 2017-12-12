using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xenarthra.DataService;
using Xenarthra.Models.extra;
using Xenarthra.Models;

namespace Xenarthra.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {

        List<Pino_Mapa> _pinos = new List<Pino_Mapa>();

        public Mapa()
        {
            InitializeComponent();
            BuscarPinos(1);
        }

        private void btnFrame_Tapped(object sender, EventArgs e)
        {
            Frame btnFrame = sender as Frame;
            btnAnteater.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            btnArmadillo.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            btnSloth.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            btnFrame.BackgroundColor = Color.FromRgb(80, 185, 72);

            BuscarPinos(Convert.ToInt32(btnFrame.StyleId));
        }

        private void mapearPinos()
        {
            //Lista de Pinos que serão adicionados no mapa
            var pinos = new List<Pin>();

            //Criando Pinos Através das Aparicoes
            foreach (Pino_Mapa _apar in _pinos)
            {
                Pin Pino = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(Convert.ToDouble(_apar.apa_Latitude), Convert.ToDouble(_apar.apa_Longitude)),
                    Label = ("#"+_apar.apa_ID.ToString()+"  Usuario: " + _apar.usu_Nome),
                    Address = "Animal: " + _apar.ani_Nome
                };

                pinos.Add(Pino);
            }

            MapadeArea.Pins.Clear();
            foreach (Pin pino in pinos)
            {
                MapadeArea.Pins.Add(pino);
            }

            foreach (Pin pino in MapadeArea.Pins)
            {
                int apa_id;
                string pino_label = pino.Label;               
                string apa_idb = pino_label.Substring(0, pino_label.IndexOf(' '));                
                apa_id = Convert.ToInt32(apa_idb.Substring(1));

                pino.Clicked += (sender, args) =>
                {
                    Navigation.PushAsync(new AparicaoDetalhado(apa_id));
                };
            }
            
            MapadeArea.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-19.500000, -60.373129), Distance.FromMiles(2500.0)));

        }

        private async void BuscarPinos(int tipo)
        {
            AparicaoService apaService = new AparicaoService();
            _pinos = await apaService.BuscarPinos(tipo);
            mapearPinos();
        }
    }
}

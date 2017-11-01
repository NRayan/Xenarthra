using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
namespace Xenarthra.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mapa : ContentPage
	{
        public Mapa ()
		{            
            InitializeComponent ();
            MapadeArea.IsShowingUser = false;
            mapearPinos();                 
        }

        private void btnFrame_Tapped(object sender, EventArgs e)
        {
            Frame btnFrame = sender as Frame;
            btnAnteater.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            btnArmadillo.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            btnSloth.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            btnFrame.BackgroundColor = Color.FromRgb(80, 185, 72);            
        }       

        private void mapearPinos()
        {
            //Lista de Pinos que serão adicionados no mapa
            var pinos = new List<Pin>();

            //Pino Basico
            var pin = new Pin
            {                
                Type = PinType.Place,
                Position = new Position(-23.569269, -47.460850),
                Label = "Norton Rayan Meira",
                Address = "animal: Bicho-Preguiça Real"                
            };

            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(-22.569269, -45.460850),
                Label = "Joaozin",
                Address = "animal: Tatu Tal"
            };

            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(-23.569269, -44.460850),
                Label = "maria dolores da silva silverio paulestina",
                Address = "animal: Tamanduá´doidao"
            };

            var pin4 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(-24.569269, -47.460850),
                Label = "Joaozin",
                Address = "animal: Tatu Tal"
            };

            pinos.Add(pin);
            pinos.Add(pin2);
            pinos.Add(pin3);
            pinos.Add(pin4);

            string aux;

            MapadeArea.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => 
            {
                var m = (CustomMap)sender;
                if (m.VisibleRegion != null)
                {
                    aux=("Lat: " + m.VisibleRegion.Center.Latitude.ToString() + " Lon:" + m.VisibleRegion.Center.Longitude.ToString());
                }
            };

            foreach (Pin pino in pinos)
            {
                MapadeArea.Pins.Add(pino);
            }

            foreach (Pin pino in MapadeArea.Pins)
            {
                pino.Clicked += (sender, args) =>
                {
                    Navigation.PushAsync(new AparicaoDetalhado());
                };
            }
           

            //Pino em Area -- Adicionando pino de area
            var position = new Position(-23.569269, -47.460850);

            MapadeArea.Circle = new CustomCircle
            {                
                Position = position,
                Radius = 6000
            };

            MapadeArea.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(10.0)));

           

        }

       
    }
}

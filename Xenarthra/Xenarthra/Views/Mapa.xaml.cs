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
            testePinoArea();
            MapadeArea.IsShowingUser = false;                        
        }

        private void btnFrame_Tapped(object sender, EventArgs e)
        {
            Frame btnFrame = sender as Frame;
            btnAnteater.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            btnArmadillo.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            btnSloth.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            btnFrame.BackgroundColor = Color.FromRgb(80, 185, 72);            
        }       

        private void testePinoArea()
        {
            //Pino Basico
            var pin = new Pin
            {                
                Type = PinType.Place,
                Position = new Position(-23.569269, -47.460850),
                Label = "Norton Rayan Meira",
                Address = "Arvore de Parque"                
            };

            pin.Clicked+=(sender,args)=>
                {
                    Navigation.PushAsync(new AparicaoDetalhado());
                };


            //Pino em Area -- Adicionando pino de area
            var position = new Position(-23.569269, -47.460850);

            MapadeArea.Circle = new CustomCircle
            {                
                Position = position,
                Radius = 6000
            };


            MapadeArea.Circle = new CustomCircle
            {
                Position = new Position(-22.569269, -45.460850),
                Radius = 6000
            };

            //Adicionando pino Basico
            MapadeArea.Pins.Add(pin);
            MapadeArea.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(10.0)));

            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(-22.569269, -45.460850),
                Label = "Joaozin",
                Address = "Arvore de Parque"
            };
            MapadeArea.Pins.Add(pin2);

        }

       
    }
}

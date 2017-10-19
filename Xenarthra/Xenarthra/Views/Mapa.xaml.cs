using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xenarthra.ViewModels;
namespace Xenarthra.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mapa : ContentPage
	{
        public MapaVM MapaViewModel { get; set; }
        public Mapa ()
		{            
            InitializeComponent ();
            MapaViewModel = new MapaVM();
            this.BindingContext = MapaViewModel;
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

            //Adicionando pino Basico
            MapadeArea.Pins.Add(pin);
            MapadeArea.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(10.0)));





            //pin.Type = PinType.Place;
            //pin.Position = new Position(-23.706278, -47.440860);
            //pin.Label = "maria";
            //pin.Address = "blablabla";

            
            //position = new Position(-23.706278, -47.440860);


            //MapadeArea.Circle = new CustomCircle
            //{
            //    Position = position,
            //    Radius = 6000
            //};
            //MapadeArea.Pins.Add(pin);
            
        }

       
    }
}

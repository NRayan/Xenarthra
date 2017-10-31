using Xamarin.Forms.Maps.Android;
using Xenarthra.Views;
using Android.Gms.Maps.Model;
using Xamarin.Forms;
using Xenarthra.Droid;
using Xamarin.Forms.Maps;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace Xenarthra.Droid{
 
    public class CustomMapRenderer : MapRenderer
    {
        CustomCircle circle;
        bool isDrawn;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                circle = formsMap.Circle;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
            {
                var circleOptions = new CircleOptions();
                circleOptions.InvokeCenter(new LatLng(circle.Position.Latitude, circle.Position.Longitude));
                circleOptions.InvokeRadius(circle.Radius);
                circleOptions.InvokeFillColor(0X66FF0000);
                circleOptions.InvokeStrokeColor(0X66FF0000);
                circleOptions.InvokeStrokeWidth(0);
                NativeMap.AddCircle(circleOptions);
                isDrawn = true;
            }      
        }
        

    }
}
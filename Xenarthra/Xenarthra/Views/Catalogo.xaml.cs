using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenarthra.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xenarthra.DataService;

namespace Xenarthra.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Catalogo : TabbedPage
    {
        List<Animal> _lista1 = new List<Animal>();
        List<Animal> _lista2 = new List<Animal>();
        List<Animal> _lista3 = new List<Animal>();

        AnimalService _aniService = new AnimalService();

        public Catalogo ()
        {
            InitializeComponent();
            CarregarListas();           
        }

        private async void CarregarListas()
        {
            _lista1 = await _aniService.ListarAnimaisPorTipo(1);
            lvBP.ItemsSource = _lista1;

            _lista2 = await _aniService.ListarAnimaisPorTipo(2);
            lvTT.ItemsSource = _lista2;

            _lista3 = await _aniService.ListarAnimaisPorTipo(3);
            lvTD.ItemsSource = _lista3;

        }

        private void lvBP_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var animal = (Animal)e.Item;
            Navigation.PushAsync(new CatalogoDetalhado(animal.ani_ID));
        }

        private void lvTT_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var animal = (Animal)e.Item;
            Navigation.PushAsync(new CatalogoDetalhado(animal.ani_ID));
        }

        private void lvTD_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var animal = (Animal)e.Item;
            Navigation.PushAsync(new CatalogoDetalhado(animal.ani_ID));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xenarthra.Models;

namespace Xenarthra.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Catalogo : ContentPage
    {
        public Catalogo()
        {
            InitializeComponent();
            this.BindingContext = this;
        }        

        Animal pxnomeanimais = new Animal();
        public List<Animal> pxNomeAnimais
        {
            get
            {
                return  pxnomeanimais.ListarNomeAnimais().OrderBy(x=>x.ani_Nome).ToList();
            }
        }

        private void sbAnimais_SearchButtonPressed(object sender, EventArgs e)
        {
            
        }
    }
}

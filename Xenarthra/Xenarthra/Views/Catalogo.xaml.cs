using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenarthra.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Xenarthra.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Catalogo : TabbedPage
    {
        public Catalogo ()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        Animal pxnomeanimais = new Animal();
        public List<Animal> pxNomeAnimais
        {
            get
            {
                return pxnomeanimais.ListarNomeAnimais().OrderBy(x => x.ani_Nome).ToList();
            }
        }

    }
}

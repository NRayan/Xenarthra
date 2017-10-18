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
        public List<Animal> pxBichosPreguica
        {
            get
            {
                return pxnomeanimais.ListarNomeBichosPreguica().OrderBy(x => x.ani_Nome).ToList();
            }
        }

        public List<Animal> pxTatus
        {
            get
            {
                return pxnomeanimais.ListarNomeTatus().OrderBy(x => x.ani_Nome).ToList();
            }
        }

        public List<Animal> pxTamanduas
        {
            get
            {
                return pxnomeanimais.ListarNomeTamanduas().OrderBy(x => x.ani_Nome).ToList();
            }
        }

    }
}

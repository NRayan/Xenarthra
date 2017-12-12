using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xenarthra.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InformacaoDetalhada : ContentPage
	{
		public InformacaoDetalhada (int opcao)
		{
			InitializeComponent ();

            if (opcao == 1)
                lblInformacao.Text = sobreAplicativo();
            else
                lblInformacao.Text = sobreXenarthras();

		}

        public string sobreAplicativo()
        {
            return @"Este trabalho tem por objetivo o desenvolvimento de uma aplicação colaborativa e multiplataforma que seja capaz de ajudar biólogos, engenheiros ambientais e florestais,
                     estudantes, pesquisadores e todos aqueles interessados nos animais que compõem a classe  Xenarthras. 
                     Esta aplicação visa catalogar estas espécies por região e assim ajudar na tarefa de proteção destes animais e do seu habitat.";

        }

         public string sobreXenarthras()
        {
            return @"Os Xenarthras ou Edentatos, são mamíferos placentários originários do continente americano há aproximadamente 60 milhões de anos. Estão distribuídos geograficamente numa região que vai desde o centro sul da América do Norte, passando pela América Central até o sul da América do Sul.
            Seu nome provém da estrutura das vértebras que são muito diferentes dos demais mamíferos. Suas vértebras dorso - lombares apresentam, além das articulações comuns, uma articulação acessória(xenartria). Também possuem dentes molares pouco desenvolvidos, o que lhes deu o nome popular de desdentados, também possuem garras nos dedos e geralmente os seus movimentos são lentos.
            São representados pelos atuais tatus, preguiças e tamanduás, compreendendo aproximadamente trinta espécies, que podem habitar ambientes florestais e áreas abertas, como savanas e desertos. Sua alimentação é principalmente de insetos ou folhas. Por serem extremamente difíceis de serem estudados, muitos Xenarthras continuam praticamente desconhecidos na natureza.Ao mesmo tempo em que a intensa degradação do meio ambiente ao longo do seu habitat têm causado um significativo declínio de suas populações.Muitos já sofreram grandes perdas, resultantes da caça indiscriminada. Devido a esses problemas, a grande parte conhecida destes animais está correndo perigo de extinção.";

        }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Xenarthra.Models
{
    public class Animal
    {
        public int ani_ID { get; set; }
        public string ani_NomeCient { get; set; }
        public string ani_Nome { get; set; }
        public byte ani_Imagem { get; set; }
        public string ani_Descricao { get; set; }
        public string ani_Familia { get; set; }

        public List<Animal> ListarAnimais()
        {
            List<Animal> lista = new List<Animal>
            {
                new Animal{ani_ID=1,ani_NomeCient="asdasd",ani_Nome="tatu",ani_Descricao="muy pequenito e macaquito",ani_Familia="tatuzoes"},
                new Animal{ani_ID=1,ani_NomeCient="bdsabdsa",ani_Nome="tamandua",ani_Descricao="doido de pedra lascada da primaveira verao de 2012 copa cabana nova iorque sao francisquinho",ani_Familia="tamanta"},
                new Animal{ani_ID=1,ani_NomeCient="bibichocho",ani_Nome="Bicho preguiça",ani_Descricao="o mais loco dos crazy night dog",ani_Familia="sloth"}
            };


            return lista;
        }

        public List<Animal> ListarNomeAnimais()
        {
            List<Animal> lista = new List<Animal>
            {
                new Animal{ani_ID=1,ani_Nome="Tatu de Rabo mole" },
                new Animal{ani_ID=1,ani_Nome="Bicho-Preguiça da roça" },
                new Animal{ani_ID=1,ani_Nome="Tamandua Bandeira" },
                new Animal{ani_ID=1,ani_Nome="Tatu doido" },
                new Animal{ani_ID=1,ani_Nome="Bicho-Preguiça da noite" },
                new Animal{ani_ID=1,ani_Nome="Tamandua lingudo" },
                new Animal{ani_ID=1,ani_Nome="Tatu de Rabo duro" },
                new Animal{ani_ID=1,ani_Nome="Bicho-Preguiça da agua" },
                new Animal{ani_ID=1,ani_Nome="Tamandua Bandeirantes" },
                new Animal{ani_ID=1,ani_Nome="Tatu pepulo" },
                new Animal{ani_ID=1,ani_Nome="Bicho-Preguiça marombeiro" },
                new Animal{ani_ID=1,ani_Nome="Tamandua ligeiro" },
                new Animal{ani_ID=1,ani_Nome="Tatu cabeludo" },
                new Animal{ani_ID=1,ani_Nome="Bicho-Preguiça da mata" },
                new Animal{ani_ID=1,ani_Nome="Tamandua pitchuba" }
            };


            return lista;
        }
    }
}

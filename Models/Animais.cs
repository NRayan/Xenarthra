using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Animais
    {
        public int ani_ID { get; set; }
        public string  ani_NomeCient { get; set; }
        public string ani_Nome { get; set; }
        public Byte[] ani_IMG { get; set; }
        public string  ani_Descricao { get; set; }
        public int  ani_Tipo { get; set; }
    }
}

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
        public string  ani_NOMECIENT { get; set; }
        public string ani_NOME { get; set; }
        public Byte[] ani_IMG { get; set; }
        public string  ani_DESCRICAO { get; set; }
        public string ani_FAMILIA { get; set; }
        public int ani_IDENTIFICACAO { get; set; }
    }
}

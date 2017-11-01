using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuarios
    {
        public int usu_ID { get; set; }
        public string usu_Nome { get; set; }
        public Byte usu_IMG { get; set; }
        public bool usu_ADM { get; set; }
        public string  usu_Email { get; set; }
        public string  usu_Senha { get; set; }
    }

}

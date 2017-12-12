using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario
    {
        public int usu_ID { get; set; }
        public string usu_Nome { get; set; }
        public string usu_IMG { get; set; }  // Json não suporta byte[], é necessário transformar o byte[] em string
        public bool usu_ADM { get; set; }
        public string  usu_Email { get; set; }
        public string  usu_Senha { get; set; }
    }

}

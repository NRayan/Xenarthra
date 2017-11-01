using System;
using System.Collections.Generic;
using System.Text;

namespace Xenarthra.Models
{
    public class Usuario
    {
        public int usu_ID { get; set; }
        public string usu_Nome { get; set; }
        public byte[] usu_IMG { get; set; }
        public string usu_Email { get; set; }
        public string usu_Senha { get; set; }
        public bool usu_ADM { get; set; }
    }
}

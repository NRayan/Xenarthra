using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Aparicoes
    {
        public int apa_ID { get; set; }
        public int apa_ID_USU { get; set; }
        public int apa_ID_ANI { get; set; }
        public string apa_COMENTARIO { get; set; }
        public bool apa_VALIDADO{ get; set; }
        public Decimal apa_LATITUDE { get; set; }
        public Decimal apa_LONGITUDE { get; set; }
    }
}

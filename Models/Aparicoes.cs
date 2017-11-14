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
        public string apa_Comentario { get; set; }
        public string apa_ComentarioADM { get; set; }
        public DateTime apa_Data { get; set; }
        public int apa_status{ get; set; }
        public Decimal apa_Latitude { get; set; }
        public Decimal apa_Longitude { get; set; }
        public Byte[] apa_IMG { get; set; }
        public int apa_tipo_animal { get; set; }
        public int apa_ID_USU { get; set; }
        public int apa_ID_ANI { get; set; }
        public string apa_Nome { get; set; }
    }
}

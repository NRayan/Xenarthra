using System;
using System.Collections.Generic;
using System.Text;

namespace Xenarthra.Models
{
    public class Aparicao
    {
        public int apa_ID { get; set; }
        public string apa_Comentario { get; set; }
        public string apa_ComentarioADM { get; set; }
        public DateTime apa_Data { get; set; }
        public decimal apa_Latitude { get; set; }
        public decimal apa_Longitude { get; set; }
        public byte[] apa_IMG { get; set; }
        public int apa_status { get; set; }
        public int apa_tipo { get; set; }
        public int apa_ID_USU { get; set; }
        public int apa_ID_ANI { get; set; }
    }
}

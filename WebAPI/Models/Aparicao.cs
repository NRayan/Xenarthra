using System;

namespace Models
{
    public class Aparicao
    {
        public int apa_ID { get; set; }
        public string apa_Comentario { get; set; }
        public string apa_ComentarioADM { get; set; }
        public DateTime apa_Data { get; set; }
        public int apa_status{ get; set; }
        public Decimal apa_Latitude { get; set; }
        public Decimal apa_Longitude { get; set; }
        public string apa_IMG { get; set; }
        public int apa_ID_USU { get; set; }
        public int apa_ID_ANI { get; set; }
    }
}

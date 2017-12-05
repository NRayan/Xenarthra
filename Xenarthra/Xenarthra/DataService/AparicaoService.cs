using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xenarthra.Models;
using Xenarthra.Models.extra;

namespace Xenarthra.DataService
{
    public class AparicaoService
    {
        HttpClient client = new HttpClient();

        public async Task<List<Pino_Mapa>> BuscarPinos(int tipo)
        {
            try
            {
                string url = "http://xenarthra.somee.com/api/APA3?tipo="+tipo.ToString();
                var resposta = await client.GetStringAsync(url);
                var endr = JsonConvert.DeserializeObject<List<Pino_Mapa>>(resposta);
              
                return endr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Aparicao> BuscarAparicao(int id)
        {
            try
            {
                string url = "http://xenarthra.somee.com/api/APA2?id=" + id.ToString();
                var resposta = await client.GetStringAsync(url);
                var endr = JsonConvert.DeserializeObject<Aparicao>(resposta);

                return endr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}

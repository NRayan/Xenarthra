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
                string url = "http://192.168.0.8:65060/api/APA3?tipo=" + tipo.ToString();
                var resposta = await client.GetStringAsync(url);
                var endr = JsonConvert.DeserializeObject<List<Pino_Mapa>>(resposta);
              
                return endr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Aparicao_Extended> BuscarAparicao(int id)
        {
            try
            {
                string url = "http://xenarthra.somee.com/api/APA2?id=" + id.ToString();
                var resposta = await client.GetStringAsync(url);
                var endr = JsonConvert.DeserializeObject<Aparicao_Extended>(resposta);

                return endr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CadastrarAparicao(Aparicao apa)
        {
            try
            {
                string url = "http://192.168.0.8:65060/api/APA4/";
                var uri = new Uri(string.Format(url, apa.apa_ID));
                var data = JsonConvert.SerializeObject(apa);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                    throw new Exception("Erro ao incluir Aparição");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xenarthra.Models;

namespace Xenarthra.DataService
{
    public class AnimalService
    {
        HttpClient client = new HttpClient();
        string Host = "http://xenarthra.somee.com";

        public async Task<List<Animal>> ListarAnimaisPorTipo(int tipo)
        {
            try
            {
                string url = Host + "/api/ANI1?tipo=" + tipo.ToString();
                var resposta = await client.GetStringAsync(url);
                var endr = JsonConvert.DeserializeObject<List<Animal>>(resposta);

                return endr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Animal> BuscarAnimal(int id)
        {
            try
            {
                string url = Host + "/api/ANI2?id=" + id.ToString();
                var resposta = await client.GetStringAsync(url);
                var endr = JsonConvert.DeserializeObject<Animal>(resposta);

                return endr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

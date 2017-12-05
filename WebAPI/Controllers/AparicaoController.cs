using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Models;
using WebAPI.Models;
using Xenarthra.Models.extra;
using WebAPI.Models.extra;

namespace WebAPI.Controllers
{
    public class AparicaoController : ApiController
    {
        DALAparicao _DALAparicao = new DALAparicao();

        [Route("api/APA1")]
        [HttpGet]
        public IEnumerable<Aparicao_Extended> ListarAparicoes(int tipo)
        {
           return _DALAparicao.ListarAparicoesPorTipoAni(tipo);
        }

        [Route("api/APA2")]
        [HttpGet]
        public Aparicao BuscarAparicao(int id)
        {
            return _DALAparicao.BuscarAparicao(id);
        }

        [Route("api/APA3")]
        [HttpGet]
        public IEnumerable<Pino_Mapa> ListarPinos(int tipo)
        {
            return _DALAparicao.ListarPinosPorTipoAni(tipo);
        }



        [Route("api/APA4")]
        [HttpPost]
        public void CadastrarAparicao(Aparicao apar)
        {
            _DALAparicao.CadastrarAparicao(apar);
        }

       
    }
}
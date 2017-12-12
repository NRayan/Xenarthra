using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Models;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AparicaoController : ApiController
    {
        DALAparicao _DALAparicao = new DALAparicao();

        [Route("api/APA1")]
        [HttpGet]
        public IEnumerable<Aparicao> ListarAparicoes(int tipo)
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
        [HttpPost]
        public void CadastrarAparicao(Aparicao apar)
        {
            _DALAparicao.CadastrarAparicao(apar);
        }
    }
}
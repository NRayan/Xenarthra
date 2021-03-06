﻿using System;
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
        public Aparicao_Extended BuscarAparicao(int id)
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
        public void CadastrarAparicao([FromBody]Aparicao apar)
        {
            _DALAparicao.CadastrarAparicao(apar);
        }

        [Route("api/APA5")]
        [HttpPut]
        public void AtualizarAparicao(int apa_id,string apa_comentarioadm,int apa_status,int apa_id_ani)
        {
            _DALAparicao.AtualizarAparicao(apa_id, apa_comentarioadm, apa_status, apa_id_ani);
        }


    }
}
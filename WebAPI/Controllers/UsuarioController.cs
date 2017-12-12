using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        DALUsuario _DALUsuario = new DALUsuario();
       

        [Route("api/Usu1")]
        [HttpPost()]
        public void CadastrarUsu([FromBody] Usuario _usu)
        {
            _DALUsuario.CadastrarUsuario(_usu);
        }

        [Route("api/Usu2")]
        [HttpGet]
        public bool ValidarUsuario(string email, string senha)
        {
            return _DALUsuario.ValidarUsuario(email, senha);
        }

        [Route("api/Usu3")]
        [HttpGet]
        public Usuario BuscarUsuarioporEmail(string email)
        {
            return _DALUsuario.BuscarUsuarioporEmail(email);
        }


    }
}
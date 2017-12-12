using System.Collections.Generic;
using Models;
using System.Web.Http;

namespace WebAPI.Models
{
    public class AnimalController : ApiController
    {
        DALAnimal _DALAnimal = new DALAnimal();

        // GET: api/Animal
        [Route("api/ANI")]
        [HttpGet]
        public IEnumerable<Animal> List()
        {
            return _DALAnimal.ListarAnimais();
        }

        [Route("api/ANI1")]
        [HttpGet]
        public IEnumerable<Animal> BuscarporTipo(int tipo)
        {
            return _DALAnimal.ListarAnimaisPorTipo(tipo);
        }

        [Route("api/ANI2")]
        [HttpGet]
        public Animal BuscarAnimal(int id)
        {
            return _DALAnimal.BuscarAnimal(id);
        }

        [Route("api/ANI3")]
        [HttpPost]
        public void CadastrarAnimal([FromBody]Animal _ani)
        {
            _DALAnimal.CadastrarAnimal(_ani);
        }




    }
}
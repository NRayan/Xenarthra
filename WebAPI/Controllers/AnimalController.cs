using System.Collections.Generic;
using Models;
using System.Web.Http;

namespace WebAPI.Models
{
    public class AnimalController : ApiController
    {
        DALAnimal _DALAnimal = new DALAnimal();

        // GET: api/Animal
        [Route("api/1")]
        [HttpGet]
        public IEnumerable<Animal> List()
        {
            return _DALAnimal.ListarAnimais();
        }

        [Route("api/2")]
        [HttpGet]
        public Animal GetAnimal(int cod)
        {
            return _DALAnimal.BuscarAnimal(cod);
        }

    }
}
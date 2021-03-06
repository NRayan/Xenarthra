﻿using System.Collections.Generic;
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
        public Animal GetAnimal(int cod)
        {
            return _DALAnimal.BuscarAnimal(cod);
        }



    }
}
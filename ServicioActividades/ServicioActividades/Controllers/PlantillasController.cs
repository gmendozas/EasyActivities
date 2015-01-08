using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServicioActividades.Models;
using RepositorioDB.MongoDb.Entidades;

namespace ServicioActividades.Controllers
{
    public class PlantillasController : ApiController
    {
        // GET: api/Plantillas
        public IEnumerable<Plantilla> Get()
        {
            Plantillas p = new Plantillas();
            return p.GetPlantillas();
        }

        // GET: api/Plantillas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Plantillas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Plantillas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Plantillas/5
        public void Delete(int id)
        {
        }
    }
}

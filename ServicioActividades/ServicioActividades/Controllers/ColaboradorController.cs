using Entidad = RepositorioDB.MongoDb.Entidades;
using ServicioActividades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioActividades.Models
{
    public class ColaboradorController : ApiController
    {
        // GET: api/Colaborador
        public IEnumerable<Entidad.Colaborador> Get()
        {
            Colaborador c = new Colaborador();
            return c.GetColaboradores();
        }

        // GET: api/Colaborador/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Colaborador
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Colaborador/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Colaborador/5
        public void Delete(int id)
        {
        }
    }
}

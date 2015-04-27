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
    public class ActividadesController : ApiController
    {
        // GET: api/Actividades
        public IEnumerable<Actividad> Get()
        {
            Actividades a = new Actividades();
            return a.GetActividades();
        }

        // GET: api/Actividades/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/Actividades/{day}")]
        public IEnumerable<Actividad> Get(string day)
        {
            Actividades a = new Actividades();
            return a.GetActividadesPorFecha(day);
        }

        // POST: api/Actividades
        public void Post(Actividad actividad)
        {
            Actividades a = new Actividades();
            a.InsertarActividad(actividad);
        }

        // PUT: api/Actividades/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Actividades/5
        public void Delete(int id)
        {
        }
    }
}

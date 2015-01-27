using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioDB.MongoDb.Entidades
{
    public class Actividad
    {
        public ObjectId Id { get; set; }
        public string Descripcion { get; set; }
        public Persona Persona { get; set; }
        public TipoActividad TipoActividad { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int Duracion { get; set; }
        public Ubicacion Ubicacion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}

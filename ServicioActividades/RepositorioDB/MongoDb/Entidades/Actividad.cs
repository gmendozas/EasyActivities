using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioDB.MongoDb.Entidades
{
    [Serializable]
    public class Actividad
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public Persona Persona { get; set; }
        public TipoActividad TipoActividad { get; set; }
        public String Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public TimeSpan Duracion { get; set; }
        public Ubicacion Ubicacion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}

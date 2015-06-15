using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositorioDB.MongoDb.Entidades
{
    [Serializable]
    public class Colaborador
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public IEnumerable<string> Correos { get; set; }
        public string Empresa { get; set; }
        public string Area { get; set; }
        public string Puesto { get; set; }
        public string FechaNacimiento { get; set; }
        public IEnumerable<string> Telefonos { get; set; }
    }
}

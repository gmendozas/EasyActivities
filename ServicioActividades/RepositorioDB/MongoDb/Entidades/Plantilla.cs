using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioDB.MongoDb.Entidades
{
    public class Plantilla
    {
        public ObjectId Id { get; set; }
        public string Nombre { get; set; }
    }
}

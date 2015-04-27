using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioDB.MongoDb.Entidades
{
    [Serializable]
    public class Ubicacion
    {
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}

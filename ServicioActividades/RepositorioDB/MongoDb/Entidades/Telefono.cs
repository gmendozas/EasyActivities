using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioDB.MongoDb.Entidades
{
    public class Telefono
    {
        public string Tipo { get; set; }
        public string NumeroTelefonico { get; set; }

        public override string ToString()
        {
            return NumeroTelefonico;
        }
    }
}

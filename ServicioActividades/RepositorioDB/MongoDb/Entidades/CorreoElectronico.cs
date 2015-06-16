using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioDB.MongoDb.Entidades
{
    public class CorreoElectronico
    {
        public string Correo { get; set; }
        public string Tipo { get; set; }

        public override string ToString()
        {
            return Correo;
        }
    }
}

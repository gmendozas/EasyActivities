using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorioDB.MongoDb.Entidades;

namespace RepositorioDB.Contratos
{
    public interface IPlantillaRepositorio
    {
        List<Plantilla> ObtenerPlantillas();
        void GuardarPlantilla(Plantilla plantilla);        
    }
}

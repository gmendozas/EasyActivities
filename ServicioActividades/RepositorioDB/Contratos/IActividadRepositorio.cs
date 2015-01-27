using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorioDB.MongoDb.Entidades;

namespace RepositorioDB.Contratos
{
    public interface IActividadRepositorio
    {
        List<Actividad> ObtenerActividades();
        void GuardarActividad(Actividad actividad);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorioDB.Contratos;
using RepositorioDB.MongoDb.Entidades;

namespace RepositorioDB.MongoDb.Repositorios
{
    public class PlantillaRepositorio : BaseRepositorio<Plantilla>, IPlantillaRepositorio
    {
        public PlantillaRepositorio(string nombreColeccion, string connectionString, string nombreBaseDatos)
            : base(nombreColeccion, connectionString, nombreBaseDatos)
        {
        }
 
        public List<Plantilla> ObtenerPlantillas()
        { 
            ConectarDb();
            return new List<Plantilla>(ObtenerTodos().Select(p => p));
        }
 
        public void GuardarPlantilla(Plantilla plantilla)
        { 
            ConectarDb();
            Insertar(plantilla);
        }
    }
}

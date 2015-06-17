using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using RepositorioDB.MongoDb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositorioDB.MongoDb.Repositorios
{
    public class ColaboradorRepositorio : BaseRepositorio<Colaborador>
    {
        public ColaboradorRepositorio(string nombreColeccion, string connectionString, string nombreBaseDatos)
            : base(nombreColeccion, connectionString, nombreBaseDatos)
        {}
 
        public IEnumerable<Colaborador> ObtenerColaboradores()
        { 
            ConectarDb();
            return ObtenerTodos().Select(a => a);
        }
 
        public void GuardarColaborador(Colaborador colaborador)
        { 
            ConectarDb();
            colaborador.RowId = Guid.NewGuid().ToString();
            Insertar(colaborador);
        }

        public IEnumerable<Colaborador> ObtenerColaboradorPorNombre(string nombre) 
        {
            ConectarDb();
            IMongoQuery query = Query.EQ("Nombres", nombre);
            return ObtenerPorFiltro(query);
        }
    
        public Colaborador ObtenerColaboradorPorId(string id)
        {
            ConectarDb();
            IMongoQuery query = Query.EQ("_id", ObjectId.Parse(id));
            Colaborador c = ObtenerUno(query);
            return c;
        }
    }
}

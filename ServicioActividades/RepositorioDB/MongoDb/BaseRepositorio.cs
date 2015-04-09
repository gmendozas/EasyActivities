using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioDB.MongoDb
{
    public class BaseRepositorio<T> where T : class
    {
        private readonly string _nombreColeccion;
        private readonly string _connectionString;
        private readonly string _nombreBaseDatos;
        private MongoDatabase database;       

        public BaseRepositorio(string nombreColeccion, string connectionString, string nombreBaseDatos)
        {
            _nombreColeccion = nombreColeccion;
            _connectionString = connectionString;
            _nombreBaseDatos = nombreBaseDatos;
        }
 
        public void ConectarDb()
        {            
            var client = new MongoClient(_connectionString);
            MongoServer server = client.GetServer();
            database = server.GetDatabase(_nombreBaseDatos);
        }
 
        public void Insertar(T entidad)
        {
            var coleccion = database.GetCollection<T>(_nombreColeccion);
            coleccion.Insert(entidad);
        }
 
        public IQueryable<T> ObtenerTodos()
        {
            var coleccion = database.GetCollection<T>(_nombreColeccion);
            return coleccion.FindAll().AsQueryable();
        }

        public IQueryable<T> ObtenerPorFiltro(IMongoQuery query)
        {
            var coleccion = database.GetCollection<T>(_nombreColeccion);
            return coleccion.Find(query).AsQueryable();
        }   
    }
}

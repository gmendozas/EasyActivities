using Entidad = RepositorioDB.MongoDb.Entidades;
using RepositorioDB.MongoDb.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace ServicioActividades.Models
{
    public class Colaborador
    {
        public IEnumerable<Entidad.Colaborador> GetColaboradores()
        {
            var connectionString = ConfigurationManager.AppSettings["mongoHost"];
            var db = ConfigurationManager.AppSettings["mongoDb"];
            ColaboradorRepositorio repositorio = new ColaboradorRepositorio("Colaborador", connectionString, db);
            return repositorio.ObtenerColaboradores();
        }
    }
}
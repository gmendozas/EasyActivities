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

        public Entidad.Colaborador GetColaborador(string id)
        {
            var connectionString = ConfigurationManager.AppSettings["mongoHost"];
            var db = ConfigurationManager.AppSettings["mongoDb"];
            ColaboradorRepositorio repositorio = new ColaboradorRepositorio("Colaborador", connectionString, db);
            return repositorio.ObtenerColaboradorPorId(id);
        }

        public void InsertarColaborador(Entidad.Colaborador colaborador)
        {
            var connectionString = ConfigurationManager.AppSettings["mongoHost"];
            var db = ConfigurationManager.AppSettings["mongoDb"];
            ColaboradorRepositorio repositorio = new ColaboradorRepositorio("Colaborador", connectionString, db);
            repositorio.GuardarColaborador(colaborador);
        }
    }
}
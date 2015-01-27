using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositorioDB.MongoDb.Entidades;
using RepositorioDB.MongoDb.Repositorios;

namespace ServicioActividades.Models
{
    public class Actividades
    {
        public List<Actividad> GetActividades()
        {
            var connectionString = ConfigurationManager.AppSettings["mongoHost"];
            var db = ConfigurationManager.AppSettings["mongoDb"];
            ActividadRepositorio repositorio = new ActividadRepositorio("Actividades", connectionString, db);
            return repositorio.ObtenerActividades();
        }

        public void InsertarActividad(Actividad actividad)
        {
            var connectionString = ConfigurationManager.AppSettings["mongoHost"];
            var db = ConfigurationManager.AppSettings["mongoDb"];
            ActividadRepositorio repositorio = new ActividadRepositorio("Actividades", connectionString, db);
            repositorio.GuardarActividad(actividad);
        }
    }
}
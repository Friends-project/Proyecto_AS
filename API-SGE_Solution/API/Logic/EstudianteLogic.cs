using API.Classes;
using API.Entidades;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Logic
{
    public class EstudianteLogic
    {
        Respuesta<Estudiante> respuesta;
        object list;
        EstudianteDB db;
        string message;
        string sentencia;

        public Respuesta<Estudiante> ObtenerEstudiantes()
        {
            list = new List<Estudiante>();
            respuesta = new Respuesta<Estudiante>();
            db = new EstudianteDB();

            sentencia = "Call ObtenerEstudiantes();";

            if (db.ObtenerEstudiantes<Estudiante>(sentencia, respuesta).MyObj == null)
            {
                respuesta.Message = db.ObtenerEstudiantes<Estudiante>(sentencia, respuesta).Log;
                return respuesta;
            }
            else
            {
                list = db.ObtenerEstudiantes<Estudiante>(sentencia, respuesta).MyObj;

                respuesta.Message = "Ok";
                respuesta.MyObj = list;
                return respuesta;
            }
        }

        public Respuesta<Estudiante> ObtenerEstudiantePorId(int id)
        {
            list = new List<Estudiante>();
            respuesta = new Respuesta<Estudiante>();
            db = new EstudianteDB();

            sentencia = "Call ObtenerEstudiantePorId(" + id + ")";

            if (db.ObtenerEstudiantes<Estudiante>(sentencia, respuesta).MyObj == null)
            {
                respuesta.Message = db.ObtenerEstudiantes<Estudiante>(sentencia, respuesta).Log;
                return respuesta;
            }
            else
            {
                list = db.ObtenerEstudiantes<Estudiante>(sentencia, respuesta).MyObj;

                respuesta.Message = "Ok";
                respuesta.MyObj = list;
                return respuesta;
            }

        }

        public Respuesta<Estudiante> AgregarEstudiante(Estudiante estudiante)
        {
            list = new List<Estudiante>();
            respuesta = new Respuesta<Estudiante>();
            db = new EstudianteDB();
            message = null;

            sentencia = "Call AgregarEstudiante(" + estudiante.Usuario.IdUsuario.ToString() + "," + estudiante.Carrera.CodigoCarrera.ToString() + "," + "'" +
            estudiante.NombreEstudiante + "'" + "," +  estudiante.DPI.ToString() + "," + "'" + estudiante.FechaIngreso + "'" + "," + "'" +
            estudiante.Telefono + "'" + "," + "'" + estudiante.Direccion + "'" + ","  + estudiante.Edad + ");";

            message = db.AgregarEstudiante<Estudiante>(sentencia, respuesta).Log;

            respuesta.Message = message;
            return respuesta;

        }

        public Respuesta<Estudiante> ModificarEstudiante(Estudiante estudiante, int id)
        {
            Respuesta<Estudiante> respuesta = new Respuesta<Estudiante>();
            message = null;
            db = new EstudianteDB();

            sentencia = "Call ModificarEstudiante(" + estudiante.IdEstudiante.ToString() + "," + estudiante.Usuario.IdUsuario.ToString() + "," + estudiante.Carrera.CodigoCarrera.ToString() + "," + "'" +
            estudiante.NombreEstudiante + "'" + "," + estudiante.DPI.ToString() + "," + "'" + estudiante.FechaIngreso + "'" + "," + "'" +
            estudiante.Telefono + "'" + "," + "'" + estudiante.Direccion + "'" + "," + estudiante.Edad + ");";

            message = db.ModificarEstudiante<Estudiante>(sentencia, respuesta).Log;

            respuesta.Message = message;
            return respuesta;

        }

        public Respuesta<Estudiante> EliminarEstudiante(int id)
        {
            Respuesta<Estudiante> respuesta = new Respuesta<Estudiante>();
            message = null;
            db = new EstudianteDB();

            sentencia = "Call EliminarEstudiante(" + id + ");";

            message = db.EliminarEstudiante<Estudiante>(sentencia, respuesta).Log;

            respuesta.Message = message;
            return respuesta;

        }

    }
}
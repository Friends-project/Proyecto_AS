using API.Classes;
using API.Entidades;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Logic
{
    public class CarreraLogic
    {

        Respuesta<Carrera> respuesta;
        object list;
        CarreraDB carreraDb;
        string message;
        string sentencia;

        public Respuesta<Carrera> ObtenerCarreras()
        {
            list = null;
            respuesta = new Respuesta<Carrera>();
            carreraDb = new CarreraDB();

            sentencia = "Call ObtenerCarreras();";

            if (carreraDb.ObtenerCarreras<Carrera>(sentencia, respuesta).MyObj == null)
            {
                respuesta.Message = carreraDb.ObtenerCarreras<Carrera>(sentencia, respuesta).Log;
                return respuesta;
            }
            else
            {
                list = carreraDb.ObtenerCarreras<Carrera>(sentencia, respuesta).MyObj;

                respuesta.Message = "Ok";
                respuesta.MyObj = list;
                return respuesta;
            }
        }

        public Respuesta<Carrera> ObtenerCarreraPorId(int id)
        {
            list = default;
            respuesta = new Respuesta<Carrera>();
            carreraDb = new CarreraDB();

            if (id < 1)
            {
                respuesta.Message = "Debes agregar el dato id para la consulta";
                return respuesta;
            }
            else
            {
                sentencia = "Call ObtenerCarreraPorId(" + id + ");";

                if (carreraDb.ObtenerCarreras<Carrera>(sentencia, respuesta).MyObj == null)
                {
                    respuesta.Message = carreraDb.ObtenerCarreras<Carrera>(sentencia, respuesta).Log;
                    return respuesta;
                }
                else
                {
                    list = carreraDb.ObtenerCarreras<Carrera>(sentencia, respuesta).MyObj;

                    respuesta.Message = "Ok";
                    respuesta.MyObj = list;
                    return respuesta;
                }
            }
        }

        public Respuesta<Carrera> AgregarCarrera(Carrera carrera)
        {
            list = new List<Carrera>();
            respuesta = new Respuesta<Carrera>();
            carreraDb = new CarreraDB();

            if (carrera == null)
            {
                respuesta.Message = "Debes agregar datos para el objeto carrera";
            }
            else
            {
                message = null;

                sentencia = "Call AgregarCarrera(" + carrera.CentroE.IdCentro + ", " + carrera.Cordinador.IdCordinador + ", '"  + carrera.NombreCarrera + "', '" + carrera.Duracion + "');";

                message = carreraDb.AgregarCarrera<Carrera>(sentencia, respuesta).Log;

                respuesta.Message = message;
            }
            
            return respuesta;

        }

        public Respuesta<Carrera> ModificarCarrera(Carrera carrera, int id)
        {
            Respuesta<Carrera> respuesta = new Respuesta<Carrera>();
            message = null;
            carreraDb = new CarreraDB();

            if (carrera == null)
            {
                respuesta.Message = "Debes agregar datos para el objeto carrera";
                return respuesta;
            }
            else
            {
                sentencia = "Call ModificarCarrera(" + id + ", " + carrera.CentroE.IdCentro + ", " + carrera.Cordinador.IdCordinador + ", '" + carrera.NombreCarrera + "', '" + carrera.Duracion + "');";

                message = carreraDb.ModificarCarrera<Carrera>(sentencia, respuesta).Log;

                respuesta.Message = message;
                return respuesta;
            }
        }

        public Respuesta<Carrera> EliminarCarrera(int id)
        {
            Respuesta<Carrera> respuesta = new Respuesta<Carrera>();
            message = null;
            carreraDb = new CarreraDB();

            sentencia = "Call EliminarCarrera("+id+");";

            message = carreraDb.EliminarCarrera<Carrera>(sentencia, respuesta).Log;

            respuesta.Message = message;
            return respuesta;

        }

    }
}
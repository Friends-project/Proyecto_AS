using API.Classes;
using API.Entidades;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Logic
{
    public class CordinadorLogic
    {

        Respuesta<Cordinador> respuesta;
        List<Cordinador> list;
        CordinadorDB db;
        string message;
        string sentencia;

        public Respuesta<Cordinador> ObtenerCordinadores()
        {
            list = new List<Cordinador>();
            respuesta = new Respuesta<Cordinador>();
            db = new CordinadorDB();

            sentencia = "Call ObtenerCordinadores();";

            if (db.ObtenerCordinadores<Cordinador>(sentencia, respuesta).MyListGen == null)
            {
                respuesta.Message = db.ObtenerCordinadores<Cordinador>(sentencia, respuesta).Log;
                return respuesta;
            }
            else
            {
                list = db.ObtenerCordinadores<Cordinador>(sentencia, respuesta).MyListGen;

                respuesta.Message = "Ok";
                respuesta.MyListGen = list;
                return respuesta;
            }
        }

        public Respuesta<Cordinador> ObtenerCordinadorPorId(int id)
        {
            list = new List<Cordinador>();
            respuesta = new Respuesta<Cordinador>();
            db = new CordinadorDB();

            if (id < 1)
            {
                respuesta.Message = "Debes agregar el dato id para la consulta";
                return respuesta;
            }
            else
            {
                sentencia = "Call ObtenerCordinadorEPorId(" + id + ");";

                if (db.ObtenerCordinadores<Cordinador>(sentencia, respuesta).MyListGen == null)
                {
                    respuesta.Message = db.ObtenerCordinadores<Cordinador>(sentencia, respuesta).Log;
                    return respuesta;
                }
                else
                {
                    list = db.ObtenerCordinadores<Cordinador>(sentencia, respuesta).MyListGen;

                    respuesta.Message = "Ok";
                    respuesta.MyObjGen = list.First();
                    return respuesta;
                }
            }
        }

    }
}
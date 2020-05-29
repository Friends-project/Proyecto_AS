using API.Classes;
using API.Entidades;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Logic
{
    public class PrivilegioLogic
    {
        Respuesta<Privilegio> respuesta;
        object list;
        PrivilegioDB db;
        string message;
        string sentencia;

        public Respuesta<Privilegio> ObtenerPrivilegios()
        {
            list = new List<Privilegio>();
            respuesta = new Respuesta<Privilegio>();
            db = new PrivilegioDB();

            sentencia = "Call ObtenerPrivilegios();";

            if (db.ObtenerPrivilegios<Privilegio>(sentencia, respuesta).MyObj == null)
            {
                respuesta.Message = db.ObtenerPrivilegios<Privilegio>(sentencia, respuesta).Log;
                return respuesta;
            }
            else
            {
                list = db.ObtenerPrivilegios<Privilegio>(sentencia, respuesta).MyObj;

                respuesta.Message = "Ok";
                respuesta.MyObj = list;
                return respuesta;
            }
        }

        public Respuesta<Privilegio> ObtenerPrivilegioPorId(int id)
        {
            list = new List<Privilegio>();
            respuesta = new Respuesta<Privilegio>();
            db = new PrivilegioDB();

            if (id < 1)
            {
                respuesta.Message = "Debes agregar el dato id para la consulta";
                return respuesta;
            }
            else
            {
                sentencia = "Call ObtenerCentroEPorId(" + id + ");";

                if (db.ObtenerPrivilegios<Privilegio>(sentencia, respuesta).MyObj == null)
                {
                    respuesta.Message = db.ObtenerPrivilegios<Privilegio>(sentencia, respuesta).Log;
                    return respuesta;
                }
                else
                {
                    list = db.ObtenerPrivilegios<Privilegio>(sentencia, respuesta).MyObj;

                    respuesta.Message = "Ok";
                    respuesta.MyObj = list;
                    return respuesta;
                }
            }
        }

    }
}
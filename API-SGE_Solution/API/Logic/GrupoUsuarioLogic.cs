using API.Classes;
using API.Entidades;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Logic
{
    public class GrupoUsuarioLogic
    {
        Respuesta<GrupoUsuario> respuesta;
        object list;
        GrupoUsuarioDB db;
        string message;
        string sentencia;

        public Respuesta<GrupoUsuario> ObtenerGrupos()
        {
            list = new List<GrupoUsuario>();
            respuesta = new Respuesta<GrupoUsuario>();
            db = new GrupoUsuarioDB();

            sentencia = "Call ObtenerGrupos();";

            if (db.ObtenerGrupos<GrupoUsuario>(sentencia, respuesta).MyObj == null)
            {
                respuesta.Message = db.ObtenerGrupos<GrupoUsuario>(sentencia, respuesta).Log;
                return respuesta;
            }
            else
            {
                list = db.ObtenerGrupos<GrupoUsuario>(sentencia, respuesta).MyObj;

                respuesta.Message = "Ok";
                respuesta.MyObj = list;
                return respuesta;
            }
        }

        public Respuesta<GrupoUsuario> ObtenerGrupoPorId(int id)
        {
            list = new List<GrupoUsuario>();
            respuesta = new Respuesta<GrupoUsuario>();
            db = new GrupoUsuarioDB();

            if (id < 1)
            {
                respuesta.Message = "Debes agregar el dato id para la consulta";
                return respuesta;
            }
            else
            {
                sentencia = "Call ObtenerGrupoPorId(" + id + ");";

                if (db.ObtenerGrupos<GrupoUsuario>(sentencia, respuesta).MyObj == null)
                {
                    respuesta.Message = db.ObtenerGrupos<GrupoUsuario>(sentencia, respuesta).Log;
                    return respuesta;
                }
                else
                {
                    list = db.ObtenerGrupos<GrupoUsuario>(sentencia, respuesta).MyObj;

                    respuesta.Message = "Ok";
                    respuesta.MyObj = list;
                    return respuesta;
                }
            }
        }

    }
}
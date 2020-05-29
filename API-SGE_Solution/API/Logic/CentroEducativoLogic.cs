using API.Classes;
using API.Entidades;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Logic
{
    public class CentroEducativoLogic
    {
        Respuesta<CentroEducativo> respuesta;
        List<CentroEducativo> list;
        CentroEducativoDB db;
        string message;
        string sentencia;

        public Respuesta<CentroEducativo> ObtenerCentrosE()
        {
            list = new List<CentroEducativo>();
            respuesta = new Respuesta<CentroEducativo>();
            db = new CentroEducativoDB();

            sentencia = "Call ObtenerCentrosE();";

            if (db.ObtenerCentroEducativos<CentroEducativo>(sentencia, respuesta).MyListGen == null)
            {
                respuesta.Message = db.ObtenerCentroEducativos<CentroEducativo>(sentencia, respuesta).Log;
                return respuesta;
            }
            else
            {
                list = db.ObtenerCentroEducativos<CentroEducativo>(sentencia, respuesta).MyListGen;

                respuesta.Message = "Ok";
                respuesta.MyListGen = list;
                return respuesta;
            }
        }

        public Respuesta<CentroEducativo> ObtenerCentroEPorId(int id)
        {
            list = new List<CentroEducativo>();
            respuesta = new Respuesta<CentroEducativo>();
            db = new CentroEducativoDB();

            if (id < 1)
            {
                respuesta.Message = "Debes agregar el dato id para la consulta";
                return respuesta;
            }
            else
            {
                sentencia = "Call ObtenerCentroEPorId(" + id + ");";

                if (db.ObtenerCentroEducativos<CentroEducativo>(sentencia, respuesta).MyListGen == null)
                {
                    respuesta.Message = db.ObtenerCentroEducativos<CentroEducativo>(sentencia, respuesta).Log;
                    return respuesta;
                }
                else
                {
                    list = db.ObtenerCentroEducativos<CentroEducativo>(sentencia, respuesta).MyListGen;

                    respuesta.Message = "Ok";
                    respuesta.MyObjGen = list.First();
                    return respuesta;
                }
            }
        }
    }
}
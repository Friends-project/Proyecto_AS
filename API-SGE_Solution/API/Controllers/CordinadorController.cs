using API.Entidades;
using API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/Cordinador")]
    public class CordinadorController : ApiController
    {
        List<Cordinador> cordinadorList;
        CordinadorLogic cordinadorLogic = new CordinadorLogic();
        string message;

        // GET: api/Cordinador/GetCordinadores
        [HttpGet]
        [Route("GetCordinadores")]
        public object GetCordinadores()
        {
            cordinadorList = new List<Cordinador>();
            if (cordinadorLogic.ObtenerCordinadores().MyListGen == null)
            {
                return cordinadorLogic.ObtenerCordinadores().Message;
            }
            else
            {
                cordinadorList = cordinadorLogic.ObtenerCordinadores().MyListGen;
                return cordinadorList;
            }
        }

        // GET: api/Cordinador/GetCordinador/{id}
        [HttpGet]
        [Route("GetCordinador")]
        public object GetCordinador(int id)
        {
            Cordinador cordinador = new Cordinador();
            if (cordinadorLogic.ObtenerCordinadorPorId(id).MyObjGen == null)
            {
                return cordinadorLogic.ObtenerCordinadorPorId(id).Message;
            }
            else
            {
                cordinador = cordinadorLogic.ObtenerCordinadorPorId(id).MyObjGen;
                return cordinador;
            }
        }

    }
}

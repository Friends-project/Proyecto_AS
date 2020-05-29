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
    [RoutePrefix("api/Privilegio")]
    public class PrivilegioController : ApiController
    {
        // GET: api/Privilegio
        object privilegioList;
        PrivilegioLogic privilegioLogic = new PrivilegioLogic();
        string message;

        // GET: api/CentroEducativo/GetCentrosEducativos
        [HttpGet]
        [Route("GetPrivilegios")]
        public object GetPrivilegios()
        {
            privilegioList = new List<Privilegio>();
            if (privilegioLogic.ObtenerPrivilegios().MyObj == null)
            {
                return privilegioLogic.ObtenerPrivilegios().Message;
            }
            else
            {
                privilegioList = privilegioLogic.ObtenerPrivilegios().MyObj;
                return privilegioList;
            }
        }

        // GET: api/Carrera/GetCarrera/{id}
        [HttpGet]
        [Route("GetPrivilegio/{id}")]
        public object GetPrivilegio(int id)
        {
            Privilegio grupo = new Privilegio();
            if (privilegioLogic.ObtenerPrivilegioPorId(id).MyObjGen == null)
            {
                return privilegioLogic.ObtenerPrivilegioPorId(id).Message;
            }
            else
            {
                grupo = privilegioLogic.ObtenerPrivilegioPorId(id).MyObjGen;
                return grupo;
            }
        }
    }
}

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
    [RoutePrefix("api/CentroE")]
    public class CentroEducativoController : ApiController
    {
        List<CentroEducativo> centroEList;
        CentroEducativoLogic centroELogic = new CentroEducativoLogic();
        string message;

        // GET: api/CentroEducativo/GetCentrosEducativos
        [HttpGet]
        [Route("GetCentrosEducativos")]
        public object GetCentrosEducativos()
        {
            centroEList = new List<CentroEducativo>();
            if (centroELogic.ObtenerCentrosE().MyListGen == null)
            {
                return centroELogic.ObtenerCentrosE().Message;
            }
            else
            {
                centroEList = centroELogic.ObtenerCentrosE().MyListGen;
                return centroEList;
            }
        }

        // GET: api/Carrera/GetCarrera/{id}
        [HttpGet]
        [Route("GetCentroEducativo")]
        public object GetCentroEducativo(int id)
        {
            CentroEducativo centroE = new CentroEducativo();
            if (centroELogic.ObtenerCentroEPorId(id).MyObjGen == null)
            {
                return centroELogic.ObtenerCentroEPorId(id).Message;
            }
            else
            {
                centroE = centroELogic.ObtenerCentroEPorId(id).MyObjGen;
                return centroE;
            }
        }

    }
}

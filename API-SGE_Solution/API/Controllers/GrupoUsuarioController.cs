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
    [RoutePrefix("api/Grupo")]
    public class GrupoUsuarioController : ApiController
    {
        // GET: api/Grupo
        object grupoList;
        GrupoUsuarioLogic grupoLogic = new GrupoUsuarioLogic();
        string message;

        // GET: api/CentroEducativo/GetCentrosEducativos
        [HttpGet]
        [Route("GetGrupos")]
        public object GetGrupos()
        {
            grupoList = new List<GrupoUsuario>();
            if (grupoLogic.ObtenerGrupos().MyObj == null)
            {
                return grupoLogic.ObtenerGrupos().Message;
            }
            else
            {
                grupoList = grupoLogic.ObtenerGrupos().MyObj;
                return grupoList;
            }
        }

        // GET: api/Carrera/GetCarrera/{id}
        [HttpGet]
        [Route("GetGrupo/{id}")]
        public object GetGrupo(int id)
        {
            GrupoUsuario grupo = new GrupoUsuario();
            if (grupoLogic.ObtenerGrupoPorId(id).MyObjGen == null)
            {
                return grupoLogic.ObtenerGrupoPorId(id).Message;
            }
            else
            {
                grupo = grupoLogic.ObtenerGrupoPorId(id).MyObjGen;
                return grupo;
            }
        }
    }
}

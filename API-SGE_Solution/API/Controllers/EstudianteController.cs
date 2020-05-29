using API.Entidades;
using API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace API.Controllers
{
    [RoutePrefix("api/Estudiante")]
    public class EstudianteController : ApiController
    {
        // GET: Estudiante
        object usuarioList;
        EstudianteLogic usuarioLogic = new EstudianteLogic();
        string message;

        [Route("GetEstudiantes")]
        [HttpGet]
        public object GetEstudiantes()
        {
            usuarioList = new List<Estudiante>();
            if (usuarioLogic.ObtenerEstudiantes().MyObj == null)
            {
                return usuarioLogic.ObtenerEstudiantes().Message;
            }
            else
            {
                usuarioList = usuarioLogic.ObtenerEstudiantes().MyObj;
                return usuarioList;
            }
        }

        // GET: api/Usuario/GetUsuario/5
        [Route("GetEstudiante")]
        [HttpGet]
        public object GetEstudiante(int id)
        {
            object usuario = new Estudiante();
            if (usuarioLogic.ObtenerEstudiantePorId(id).MyObj == null)
            {
                return usuarioLogic.ObtenerEstudiantePorId(id).Message;
            }
            else
            {
                usuario = usuarioLogic.ObtenerEstudiantePorId(id).MyObj;
                return usuario;
            }
        }

        // POST: api/Usuario/PostUsuario
        [HttpPost]
        [Route("AgregarEstudiante")]
        public string AgregarEstudiante(Estudiante user)
        {
            message = null;
            message = usuarioLogic.AgregarEstudiante(user).Message;

            return message;
        }

        // PUT: api/Usuario/PutUsuario/5
        [HttpPut]
        [Route("ModificarEstudiante")]
        public string ModificarEstudiante(Estudiante user, int id)
        {
            message = null;
            message = usuarioLogic.ModificarEstudiante(user, id).Message;

            return message;
        }

        // DELETE: api/Usuario/Delete/5
        [Route("EliminarEstudiante")]
        [HttpDelete]
        public string EliminarEstudiante(int id)
        {
            message = null;
            message = usuarioLogic.EliminarEstudiante(id).Message;

            return message;
        }
    }
}

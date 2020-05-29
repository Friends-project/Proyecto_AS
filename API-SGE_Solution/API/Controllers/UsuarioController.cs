using API.Classes;
using API.Entidades;
using API.Logic;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        object usuarioList;
        UsuarioLogic usuarioLogic = new UsuarioLogic();
        string message;

        [Route("GetUsuarios")]
        [HttpGet]
        public object GetUsuarios()
        {
            usuarioList = new List<Usuario>();
            if (usuarioLogic.ObtenerUsuarios().MyObj == null)
            {
                return usuarioLogic.ObtenerUsuarios().Message;
            }
            else
            {
                usuarioList = usuarioLogic.ObtenerUsuarios().MyObj;
                return usuarioList;
            }
        }

        // GET: api/Usuario/GetUsuario/5
        [Route("GetUsuario")]
        [HttpGet]
        public object GetUsuario(int id)
        {
            object usuario = new Usuario();
            if (usuarioLogic.ObtenerUsuarioPorId(id).MyObj == null)
            {
                return usuarioLogic.ObtenerUsuarioPorId(id).Message;
            }
            else
            {
                usuario = usuarioLogic.ObtenerUsuarioPorId(id).MyObj;
                return usuario;
            }
        }

        // POST: api/Usuario/PostUsuario
        [HttpPost]
        [Route("AgregarUsuario")]
        public string PostUsuario(Usuario user)
        {
            message = null;
            message = usuarioLogic.AgregarUsuario(user).Message;

            return message;
        }

        // PUT: api/Usuario/PutUsuario/5
        [HttpPut]
        [Route("ModificarUsuario")]
        public string PutUsuario(Usuario user, int id)
        {
            message = null;
            message = usuarioLogic.ModificarUsuario(user, id).Message;

            return message;
        }

        // DELETE: api/Usuario/Delete/5
        [Route("EliminarUsuario")]
        public string Delete(int id)
        {
            message = null;
            message = usuarioLogic.EliminarUsuario(id).Message;

            return message;
        }
    }
}

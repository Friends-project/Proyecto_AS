using API.Classes;
using API.Entidades;
using API.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API.Logic
{
    public class UsuarioLogic
    {
        Respuesta<Usuario> respuesta;
        object list;
        UsuarioDB db;
        string message;
        string sentencia;

        public Respuesta<Usuario> ObtenerUsuarios()
        {
            list = new List<Usuario>();
            respuesta = new Respuesta<Usuario>();
            db = new UsuarioDB();

            sentencia = "Call ObtenerUsuarios();";

            if (db.ObtenerUsuarios<Usuario>(sentencia, respuesta).MyObj == null)
            {
                respuesta.Message = db.ObtenerUsuarios<Usuario>(sentencia, respuesta).Log;
                return respuesta;
            }
            else
            {
                list = db.ObtenerUsuarios<Usuario>(sentencia, respuesta).MyObj;

                respuesta.Message = "Ok";
                respuesta.MyObj = list;
                return respuesta;
            }
        }

        public Respuesta<Usuario> ObtenerUsuarioPorId(int id)
        {
            list = new List<Usuario>();
            respuesta = new Respuesta<Usuario>();
            db = new UsuarioDB();

            sentencia = "Call ObtenerUsuarioPorId("+ id +")";

            if (db.ObtenerUsuarios<Usuario>(sentencia, respuesta).MyObj == null)
            {
                respuesta.Message = db.ObtenerUsuarios<Usuario>(sentencia, respuesta).Log;
                return respuesta;
            }
            else
            {
                list = db.ObtenerUsuarios<Usuario>(sentencia, respuesta).MyObj;

                respuesta.Message = "Ok";
                respuesta.MyObj = list;
                return respuesta;
            }

        }

        public Respuesta<Usuario> AgregarUsuario(Usuario usuario)
        {
            list = new List<Usuario>();
            respuesta = new Respuesta<Usuario>();
            db = new UsuarioDB();
            message = null;

            sentencia = "Call AgregarUsuario(" + usuario.Grupo.IdGrupo.ToString() + "," + usuario.Privilegio.IdPrivilegio.ToString() + "," + "'" +
            usuario.FechaCreacion.ToString("yyyy/MM/dd") + "'" + "," + "'" + usuario.UsuarioEmail.ToString() + "'" + "," + "'" + usuario.Contrasena.ToString() + "'" + ");";

            message = db.AgregarUsuario<Usuario>(sentencia, respuesta).Log;

            respuesta.Message = message;
            return respuesta;

        }

        public Respuesta<Usuario> ModificarUsuario(Usuario usuario, int id)
        {
            Respuesta<Usuario> respuesta = new Respuesta<Usuario>();
            message = null;
            db = new UsuarioDB();

            sentencia = "Call ModificarUsuario(" + usuario.IdUsuario.ToString() + "," + usuario.Grupo.IdGrupo.ToString() + "," + usuario.Privilegio.IdPrivilegio.ToString() + "," + "'" +
            usuario.FechaCreacion.ToString("yyyy/MM/dd") + "'" + "," + "'" + usuario.UsuarioEmail.ToString() + "'" + "," + "'" + usuario.Contrasena.ToString() + "'" + ");";

            message = db.ModificarUsuario<Usuario>(sentencia, respuesta).Log;

            respuesta.Message = message;
            return respuesta;

        }

        public Respuesta<Usuario> EliminarUsuario(int id)
        {
            Respuesta<Usuario> respuesta = new Respuesta<Usuario>();
            message = null;
            db = new UsuarioDB();

            sentencia = "Call EliminarUsuario(" + id + ");";

            message = db.EliminarUsuario<Usuario>(sentencia, respuesta).Log;

            respuesta.Message = message;
            return respuesta;

        }
    }
}

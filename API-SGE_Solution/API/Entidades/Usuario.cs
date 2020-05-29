using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public GrupoUsuario Grupo { get; set; }
        public Privilegio Privilegio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioEmail { get; set; }
        public string Contrasena { get; set; }

        public Usuario()
        {
            IdUsuario = 0;
            Grupo = new GrupoUsuario();
            Privilegio = new Privilegio();
            FechaCreacion = new DateTime();
            UsuarioEmail = String.Empty;
            Contrasena = String.Empty;
        }
    }
}
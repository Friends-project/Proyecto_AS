using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SITIO.Entidades
{
    public class Usuario
    {
        [Required]
        [DisplayName("Codigo")]
        public int IdUsuario { get; set; }
        [Required]
        [DisplayName("Grupo")]
        public GrupoUsuario Grupo { get; set; }
        [Required]
        [DisplayName("Privilegio")]
        public Privilegio Privilegio { get; set; }
        [Required]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DisplayName("Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }
        [Required]
        [DisplayName("Usuario")]
        public string UsuarioEmail { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Contrasena { get; set; }

        public Usuario()
        {
            IdUsuario = 0;
            Grupo = new GrupoUsuario();
            Privilegio = new Privilegio();
            FechaCreacion = DateTime.Now;
            UsuarioEmail = String.Empty;
            Contrasena = String.Empty;
        }
    }
}
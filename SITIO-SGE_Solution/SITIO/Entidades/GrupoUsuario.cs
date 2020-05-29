using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace SITIO.Entidades
{
    public class GrupoUsuario
    {
        [Required]
        [DisplayName("Codigo")]
        public int IdGrupo { get; set; }
        [Required]
        [DisplayName("Centro Educativo")]
        public CentroEducativo CentroE { get; set; }
        [Required]
        [DisplayName("NOmbre Grupo")]
        public string NombreGrupo { get; set; }

        public GrupoUsuario()
        {
            IdGrupo = 0;
            CentroE = new CentroEducativo();
            NombreGrupo =String.Empty;
        }
    }
}
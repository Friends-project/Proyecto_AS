using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace API.Entidades
{
    public class GrupoUsuario
    {
        public int IdGrupo { get; set; }
        public CentroEducativo CentroE { get; set; }
        public string NombreGrupo { get; set; }

        public GrupoUsuario()
        {
            IdGrupo = 0;
            CentroE = new CentroEducativo();
            NombreGrupo =String.Empty;
        }
    }
}
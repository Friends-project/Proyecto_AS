using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entidades
{
    public class CentroEducativo
    {
        public int IdCentro { get; set; }
        public string NombreCentro { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public CentroEducativo()
        {
            IdCentro = 0;
            NombreCentro = String.Empty;
            Telefono = String.Empty;
            Email = String.Empty;
            Direccion = String.Empty;
        }
    }
}
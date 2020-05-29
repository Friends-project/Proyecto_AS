using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SITIO.Entidades
{
    public class CentroEducativo
    {
        [Required]
        [DisplayName("Id Centro Educativo")]
        public int IdCentro { get; set; }
        [Required]
        [DisplayName("Nombre Centro Educativo")]
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
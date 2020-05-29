using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SITIO.Entidades
{
    public class Carrera
    {
        [Required]
        [DisplayName("Código")]
        public int CodigoCarrera { get; set; }
        [Required]
        [DisplayName("Centro Educativo")]
        public CentroEducativo CentroE { get; set; }
        [Required]
        [DisplayName("Coordinador")]
        public Cordinador Cordinador { get; set; }
        [Required]
        [DisplayName("Carrera")]
        public string NombreCarrera { get; set; }
        [Required]
        [DisplayName("Duración")]
        public string Duracion { get; set; }

        public Carrera()
        {
            CodigoCarrera = 0;
            CentroE = new CentroEducativo();
            Cordinador = new Cordinador();
            NombreCarrera = String.Empty;
            Duracion = String.Empty;
        }
    }
}
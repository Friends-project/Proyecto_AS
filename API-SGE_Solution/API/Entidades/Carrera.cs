using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Entidades
{
    public class Carrera
    {
        [Required]
        public int CodigoCarrera { get; set; }
        [Required]
        public CentroEducativo CentroE { get; set; }
        [Required]
        public Cordinador Cordinador { get; set; }
        [Required]
        public string NombreCarrera { get; set; }
        [Required]
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SITIO.Entidades
{
    public class Estudiante
    {
        [Required]
        [DisplayName("Codigo")]
        public int IdEstudiante { get; set; }
        [Required]
        [DisplayName("Usuario")]
        public Usuario Usuario { get; set; }
        [Required]
        [DisplayName("Carrera")]
        public Carrera Carrera { get; set; }
        [Required]
        [DisplayName("Nombre Estudiante")]
        public string NombreEstudiante { get; set; }
        [Required]
        [DisplayName("DPI")]
        public long DPI { get; set; }
        [Required]
        [DisplayName("Fecha Ingreso")]
        public string FechaIngreso { get; set; }
        [Required]
        [DisplayName("Telefono")]
        public string Telefono { get; set; }
        [Required]
        [DisplayName("Direccion")]
        public string Direccion { get; set; }
        [Required]
        [DisplayName("Edad")]
        public int Edad { get; set; }

        public Estudiante()
        {
            IdEstudiante = 0;
            Usuario = new Usuario();
            Carrera = new Carrera();
            NombreEstudiante = String.Empty;
            DPI = 0;
            FechaIngreso = String.Empty;
            Telefono = String.Empty;
            Direccion = String.Empty;
            Edad = 0;

        }
    }
}
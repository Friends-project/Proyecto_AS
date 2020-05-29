using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entidades
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        public Usuario Usuario { get; set; }
        public Carrera Carrera { get; set; }
        public string NombreEstudiante { get; set; }
        public long DPI { get; set; }
        public string FechaIngreso { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
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
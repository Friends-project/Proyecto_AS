using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Web;

namespace SITIO.Entidades
{
    public class Cordinador
    {
        [Required]
        [DisplayName("Id Coordinador")]
        public int IdCordinador { get; set; }
        [Required]
        [DisplayName("Nombre Coordinador")]
        public string NombreCordinador { get; set; }
        public long NIT { get; set; }
        public long DPI { get; set; }
        //Ignora la propiedad si su valor es nulo dentro del formato json
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime FechaIngreso { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string Estado { get; set; }
        public string FechaEgreso { get; set; }

        public Cordinador()
        {
            IdCordinador = 0;
            NombreCordinador = String.Empty;
            NIT = 0;
            DPI = 0;
            FechaIngreso = new DateTime();
            Telefono = String.Empty;
            Direccion = String.Empty;
            Edad = 0;
            Estado = String.Empty;
            FechaEgreso = String.Empty;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entidades
{
    public class Cordinador
    {
        public int IdCordinador { get; set; }
        public string NombreCordinador { get; set; }
        public long NIT { get; set; }
        public long DPI { get; set; }
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
            FechaIngreso =  new DateTime();
            Telefono = String.Empty;
            Direccion = String.Empty;
            Edad = 0;
            Estado = String.Empty;
            FechaEgreso = String.Empty;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entidades
{
    public class Privilegio
    {
        public int IdPrivilegio { get; set; }
        public string NombrePrivilegio { get; set; }

        public Privilegio()
        {
            IdPrivilegio = 0;
            NombrePrivilegio = String.Empty;
        }
    }
}
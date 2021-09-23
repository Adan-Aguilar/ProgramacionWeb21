using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad2U1.Models
{
    public class PaginaPromedioViewModel
    {
        public int Calificacion1 { get; set; }
        public int Calificacion2 { get; set; }
        public int Calificacion3 { get; set; }

        public int resultado { get { return (Calificacion1 + Calificacion2 + Calificacion3)/3; } }


    }
}

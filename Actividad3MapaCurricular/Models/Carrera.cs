using System;
using System.Collections.Generic;

#nullable disable

namespace Actividad3MapaCurricular.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Materia = new HashSet<Materia>();
        }

        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Plan { get; set; }
        public string Especialidad { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Materia> Materia { get; set; }
    }
}

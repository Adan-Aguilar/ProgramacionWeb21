﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Act2PresidentesMexico.Models
{
    public partial class Partidopolitico
    {
        public Partidopolitico()
        {
            Presidentes = new HashSet<Presidente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Presidente> Presidentes { get; set; }
    }
}

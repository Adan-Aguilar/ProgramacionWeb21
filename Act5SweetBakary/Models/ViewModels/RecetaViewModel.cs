﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Act5SweetBakary.Models.ViewModels
{
    public class RecetaViewModel
    {
        public Receta Receta { get; set; } //Entidad de la bd

        public IEnumerable<Receta> TresRecetas { get; set; }
        //No requiero cargar toda la información
    }
}

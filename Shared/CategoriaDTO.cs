﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaSur.Shared
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }
        public string? NombreCategoria { get; set; }

        public DateTime? FechaRegistro { get; set; }
        //public bool EsActivo { get; set; } = true;

        public override bool Equals(object o)
        {
            var other = o as CategoriaDTO;
            return other?.IdCategoria == IdCategoria;
        }
        public override int GetHashCode() => IdCategoria.GetHashCode();
        public override string ToString()
        {
            return NombreCategoria;
        }
    }
}

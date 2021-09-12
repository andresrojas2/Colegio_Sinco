﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Colegio.Models.Models
{
    public partial class Profesor
    {
        public int Id { get; set; }
        public long? Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Edad { get; set; }
        public string Direccion { get; set; }
        public long? Telefono { get; set; }
        public int? MateriaId { get; set; }

        public virtual Materium Materia { get; set; }
    }
}

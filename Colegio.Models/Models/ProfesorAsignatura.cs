using System;
using System.Collections.Generic;

#nullable disable

namespace Colegio.Models.Models
{
    public partial class ProfesorAsignatura
    {
        public int Id { get; set; }
        public int? MateriaId { get; set; }
        public int? ProfesorId { get; set; }

        public virtual Materium Materia { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}

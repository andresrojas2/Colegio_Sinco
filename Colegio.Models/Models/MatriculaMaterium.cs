using System;
using System.Collections.Generic;

#nullable disable

namespace Colegio.Models.Models
{
    public partial class MatriculaMaterium
    {
        public int Id { get; set; }
        public int? MateriaId { get; set; }
        public int? AlumnoId { get; set; }
        public int? Periodo { get; set; }
        public int? Nota { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Materium Materia { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Colegio.Dtos
{
    public class MatriculaMateriaDto
    {
        public int Id { get; set; }
        public int? MateriaId { get; set; }
        public int? AlumnoId { get; set; }
        public int? Periodo { get; set; }
        public int? Nota { get; set; }

        public virtual AlumnoDto Alumno { get; set; }
        public virtual MateriaDto Materia { get; set; }
    }
}

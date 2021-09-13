using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Colegio.Dtos
{
    public class MatriculaMateriaDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Materia es obligatorio")]
        [Display(Name = "Materia")]
        public int? MateriaId { get; set; }

        [Required(ErrorMessage = "Alumno es obligatorio")]
        [Display(Name = "Alumno")]
        public int? AlumnoId { get; set; }

        [Required(ErrorMessage = "Periodo es obligatorio")]
        [Display(Name = "Periodo")]
        public int? Periodo { get; set; }

        [Required(ErrorMessage = "Nota es obligatorio")]
        [Display(Name = "Nota")]
        [Range(typeof(double), "0", "5", ErrorMessage = "Nota debe ser un valor de 0 a 5")]
        public double? Nota { get; set; }

        public virtual AlumnoDto Alumno { get; set; }
        public virtual MateriaDto Materia { get; set; }
    }
}

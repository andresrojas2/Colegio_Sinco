using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Dtos
{
    public class ReporteCalificacionesDto
    {
        public int Id { get; set; }


        [Display(Name = "Materia")]
        public int? MateriaId { get; set; }

        [Display(Name = "Alumno")]
        public int? AlumnoId { get; set; }

        [Display(Name = "Año académico")]
        public int? Periodo { get; set; }

        [Display(Name = "Código Materia")]
        public int CodigoMateria { get; set; }

        [Display(Name = "Nombre Materia")]
        public string NombreMateria { get; set; }

        [Display(Name = "Calificación final")]
        public double? Nota { get; set; }

        [Display(Name = "Identificación Alumno")]
        public long IdentificacionAlumno { get; set; }

        [Display(Name = "Nombre del alumno")]
        public string NombreCompletoAlumno { get; set; }

        [Display(Name = "Identificación del profesor")]
        public long IdentificacionProfesor { get; set; }

        [Display(Name = "Nombre del profesor")]
        public string NombreCompletoProfesor { get; set; }

        [Display(Name = "Aprobó")]
        public string Aprueba { get; set; }

        public virtual AlumnoDto Alumno { get; set; }
        public virtual MateriaDto Materia { get; set; }
    }
}

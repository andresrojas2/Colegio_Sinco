using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Colegio.Dtos
{
    public class MateriaDto
    {
        public MateriaDto()
        {
            MatriculaMateria = new HashSet<MatriculaMateriaDto>();
            Profesors = new HashSet<ProfesorDto>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Código es obligatorio")]
        [Display(Name = "Código")]
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        public virtual ICollection<MatriculaMateriaDto> MatriculaMateria { get; set; }
        public virtual ICollection<ProfesorDto> Profesors { get; set; }
    }
}

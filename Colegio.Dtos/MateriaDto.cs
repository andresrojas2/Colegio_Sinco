using System;
using System.Collections.Generic;
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
        public int? Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<MatriculaMateriaDto> MatriculaMateria { get; set; }
        public virtual ICollection<ProfesorDto> Profesors { get; set; }
    }
}

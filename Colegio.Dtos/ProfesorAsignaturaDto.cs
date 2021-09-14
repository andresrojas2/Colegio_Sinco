using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Dtos
{
    public class ProfesorAsignaturaDto
    {

        public int Id { get; set; }
        public int? MateriaId { get; set; }
        public int? ProfesorId { get; set; }

        public virtual MateriaDto Materia { get; set; }
        public virtual ProfesorDto Profesor { get; set; }
    }
}

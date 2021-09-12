using System;
using System.Collections.Generic;
using System.Text;

namespace Colegio.Dtos
{
    public class AlumnoDto
    {
        public int Id { get; set; }
        public long? Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Edad { get; set; }
        public string Direccion { get; set; }
        public long? Telefono { get; set; }
        public int? MateriaId { get; set; }

        public virtual MateriaDto Materia { get; set; }
    }
}

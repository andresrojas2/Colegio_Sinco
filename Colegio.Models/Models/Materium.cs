using System;
using System.Collections.Generic;

#nullable disable

namespace Colegio.Models.Models
{
    public partial class Materium
    {
        public Materium()
        {
            MatriculaMateria = new HashSet<MatriculaMaterium>();
            ProfesorAsignaturas = new HashSet<ProfesorAsignatura>();
        }

        public int Id { get; set; }
        public int? Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<MatriculaMaterium> MatriculaMateria { get; set; }
        public virtual ICollection<ProfesorAsignatura> ProfesorAsignaturas { get; set; }
    }
}

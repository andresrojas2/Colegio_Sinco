using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Colegio.Dtos
{
    public class ProfesorDto
    {
        public ProfesorDto()
        {
            ProfesorAsignaturas = new HashSet<ProfesorAsignaturaDto>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Identificación es obligatorio")]
        [Display(Name = "Identificación")]
        public long? Identificacion { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es obligatorio")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Edad es obligatorio")]
        [Display(Name = "Edad")]
        public int? Edad { get; set; }


        [Required(ErrorMessage = "Dirección es obligatorio")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }


        [Required(ErrorMessage = "Teléfono es obligatorio")]
        [Display(Name = "Teléfono")]
        public long? Telefono { get; set; }

        public virtual ICollection<ProfesorAsignaturaDto> ProfesorAsignaturas { get; set; }
    }
}

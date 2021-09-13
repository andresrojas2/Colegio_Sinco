using Colegio.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Repositorios
{
    public interface IReporteCalificacionRepositorio
    {
        Task<IEnumerable<ReporteCalificacionesDto>> ReporteCalificacion();
    }
}

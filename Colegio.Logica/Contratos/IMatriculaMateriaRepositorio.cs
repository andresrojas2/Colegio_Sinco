using Colegio.Logica.Repositorios;
using Colegio.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Contratos
{
    public interface IMatriculaMateriaRepositorio : IRepositorioGenerico<MatriculaMaterium>
    {

        Task<IEnumerable<MatriculaMaterium>> ObtenerXAlumnoAsync(int EstudianteId);

        Task<bool> ValidarMateriaPeriodo(int AlumnoId, int MateriaId, int Periodo, int? Id = null);

        Task<IEnumerable<MatriculaMaterium>> Other();
    }
}

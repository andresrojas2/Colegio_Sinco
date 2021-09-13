using Colegio.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Repositorios
{
    public interface IMatriculaMateriaRepositorio : IRepositorioGenerico<MatriculaMaterium>
    {

        Task<IEnumerable<MatriculaMaterium>> ObtenerXAlumnoAsync(int EstudianteId);
    }
}

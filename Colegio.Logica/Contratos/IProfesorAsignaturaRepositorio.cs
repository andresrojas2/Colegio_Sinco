using Colegio.Logica.Repositorios;
using Colegio.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Contratos
{
    public interface IProfesorAsignaturaRepositorio : IRepositorioGenerico<ProfesorAsignatura>
    {

        Task<IEnumerable<ProfesorAsignatura>> ObtenerXProfesorAsync(int ProfesorId);

        Task<bool> ValidarMateria(int MateriaId);

    }
}

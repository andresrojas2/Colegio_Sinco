using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Repositorios
{
    public interface IEliminar<T> where T : class
    {
        Task<bool> Eliminar(int id);
    }
}

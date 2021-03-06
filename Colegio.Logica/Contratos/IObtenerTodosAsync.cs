using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Contratos
{
    public interface IObtenerTodosAsync<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodosAsync();
    }
}

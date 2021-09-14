using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Contratos
{
    public interface IObtenerAsync<T> where T : class
    {
        Task<T> ObtenerAsync(int id);
    }
}

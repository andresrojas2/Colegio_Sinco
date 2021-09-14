using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Repositorios
{
    public interface IAgregar<T> where T : class
    {
        Task<T> Agregar(T entity);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Repositorios
{
    public interface IRepositorioGenerico<T> where T : class
    {


        Task<IEnumerable<T>> ObtenerTodosAsync();
        Task<T> ObtenerAsync(int id);
        Task<T> Agregar(T entity);
        Task<bool> Actualizar(T entity);
        Task<bool> Eliminar(int id);


    }
}

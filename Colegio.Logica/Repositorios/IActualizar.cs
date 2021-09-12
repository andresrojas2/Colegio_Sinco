﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Repositorios
{
    public interface IActualizar<T> where T : class
    {
        Task<bool> Actualizar(T entity);
    }
}

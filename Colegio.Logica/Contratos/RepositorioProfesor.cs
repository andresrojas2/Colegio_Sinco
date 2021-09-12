﻿using Colegio.Logica.Repositorios;
using Colegio.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Contratos
{
    public class RepositorioProfesor : IProfesorRepositorio
    {
        private ColegioContext _context;
        private DbSet<Profesor> _dbSet;

        public RepositorioProfesor(ColegioContext context)
        {
            _context = context;
            this._dbSet = _context.Set<Profesor>();
        }
        //public List<Cliente> ConsultarClientes()
        //{
        //    return _context.Clientes.ToList();
        //}

        public async Task<bool> Actualizar(Profesor entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<Profesor> Agregar(Profesor entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Eliminar(int id)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(u => u.Id == id);
            _dbSet.Remove(entity);
            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }

        public async Task<Profesor> ObtenerAsync(int id)
        {
            return await _dbSet.Include(u => u.Materia).SingleOrDefaultAsync(c => c.Id == id);
        }



        public async Task<IEnumerable<Profesor>> ObtenerTodosAsync()
        {
            return await _dbSet.Include(u => u.Materia).ToListAsync();
        }

    }
}


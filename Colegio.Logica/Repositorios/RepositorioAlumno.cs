using Colegio.Logica.Contratos;
using Colegio.Logica.Repositorios;
using Colegio.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Repositorios
{
    public class RepositorioAlumno : IAlumnoRepositorio
    {
        private ColegioContext _context;
        private DbSet<Alumno> _dbSet;

        public RepositorioAlumno(ColegioContext context)
        {
            _context = context;
            this._dbSet = _context.Set<Alumno>();
        }

        public async Task<bool> Actualizar(Alumno entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<Alumno> Agregar(Alumno entity)
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

        public async Task<Alumno> ObtenerAsync(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(c => c.Id == id);
        }



        public async Task<IEnumerable<Alumno>> ObtenerTodosAsync()
        {
            return await _dbSet.Include(u => u.MatriculaMateria).ToListAsync();
        }

    }
}


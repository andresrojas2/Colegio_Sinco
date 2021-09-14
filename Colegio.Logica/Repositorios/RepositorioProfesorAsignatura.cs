using Colegio.Logica.Contratos;
using Colegio.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Logica.Repositorios
{
    public class RepositorioProfesorAsignatura : IProfesorAsignaturaRepositorio
    {
        private ColegioContext _context;
        private DbSet<ProfesorAsignatura> _dbSet;

        public RepositorioProfesorAsignatura(ColegioContext context)
        {
            _context = context;
            this._dbSet = _context.Set<ProfesorAsignatura>();
        }
  
        public async Task<bool> Actualizar(ProfesorAsignatura entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<ProfesorAsignatura> Agregar(ProfesorAsignatura entity)
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

        public async Task<ProfesorAsignatura> ObtenerAsync(int id)
        {
            return await _dbSet.Include(u => u.Materia)
                               .Include(u => u.Profesor).SingleOrDefaultAsync(c => c.Id == id);
        }


        public async Task<IEnumerable<ProfesorAsignatura>> ObtenerTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }


        public async Task<IEnumerable<ProfesorAsignatura>> ObtenerXProfesorAsync(int ProfesorId)
        {
            return await _dbSet.Include(u => u.Materia)
                               .Include(u => u.Profesor)
                               .Where(c => c.ProfesorId == ProfesorId).ToListAsync();
        }

        public async Task<bool> ValidarMateria(int MateriaId)
        {
                return await _dbSet.AnyAsync(c => c.MateriaId == MateriaId);
           
        }
    }
}

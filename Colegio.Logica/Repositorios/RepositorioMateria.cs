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
    public class RepositorioMateria : IMateriaRepositorio
    {
        private ColegioContext _context;
        private DbSet<Materium> _dbSet;

        public RepositorioMateria(ColegioContext context)
        {
            _context = context;
            this._dbSet = _context.Set<Materium>();
        }

        public async Task<bool> Actualizar(Materium entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<Materium> Agregar(Materium entity)
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

        public async Task<Materium> ObtenerAsync(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(c => c.Id == id);
        }



        public async Task<IEnumerable<Materium>> ObtenerTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }

    }
}

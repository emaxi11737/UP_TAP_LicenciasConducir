using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Infrastructure.Data;

namespace UP_TAP_LicenciasConducir.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly LicenciasConducirDataContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(LicenciasConducirDataContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();

        }

        public virtual async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

     

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task BulkInsert(List<T> list)
        {
            await _context.BulkInsertAsync(list);
        }
        public async Task BulkUpdate(List<T> list)
        {
            await _context.BulkUpdateAsync(list);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
    }
}

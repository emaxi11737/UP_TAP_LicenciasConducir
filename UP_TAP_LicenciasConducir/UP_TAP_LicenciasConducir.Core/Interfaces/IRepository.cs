using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities;

namespace UP_TAP_LicenciasConducir.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        public Task BulkInsert(List<T> list);
        public Task BulkUpdate(List<T> list);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UP_TAP_LicenciasConducir.Core.Entities;

namespace UP_TAP_LicenciasConducir.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Question> QuestionRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}

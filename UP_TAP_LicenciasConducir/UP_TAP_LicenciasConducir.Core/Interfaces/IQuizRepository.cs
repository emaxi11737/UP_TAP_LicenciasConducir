using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities;

namespace UP_TAP_LicenciasConducir.Core.Interfaces
{
    public interface IQuizRepository : IRepository<Quiz>
    {
        public IEnumerable<Quiz> GetAllInclude();

    }
}

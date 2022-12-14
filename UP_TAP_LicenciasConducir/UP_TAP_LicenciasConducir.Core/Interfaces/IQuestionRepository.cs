using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities;

namespace UP_TAP_LicenciasConducir.Core.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        public IEnumerable<Question> GetAllInclude();

    }
}

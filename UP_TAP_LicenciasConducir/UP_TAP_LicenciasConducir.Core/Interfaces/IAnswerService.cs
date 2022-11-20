using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.CustomEntities;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.QueryFilters;

namespace UP_TAP_LicenciasConducir.Core.Interfaces
{
    public interface IAnswerService
    {
        PagedList<Answer> GetAnswers(QueryFilter filters);

        Task<Answer> GetAnswer(int id);

        Task InsertAnswer(Answer post);

        Task<bool> UpdateAnswer(Answer post);

        Task<bool> DeleteAnswer(int id);
    }
}


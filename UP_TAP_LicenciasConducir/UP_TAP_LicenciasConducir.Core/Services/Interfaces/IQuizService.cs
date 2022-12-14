using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.CustomEntities;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.QueryFilters;

namespace UP_TAP_LicenciasConducir.Core.Services.Interfaces
{
    public interface IQuizService
    {
        Task<bool> UpdateQuiz(Quiz quiz);
        Task InsertQuiz(Quiz quiz);
        Quiz GetQuiz(int id);

    }
}


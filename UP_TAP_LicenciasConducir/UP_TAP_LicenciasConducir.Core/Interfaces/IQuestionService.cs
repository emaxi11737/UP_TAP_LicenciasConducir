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
    public interface IQuestionService
    {
        PagedList<Question> GetQuestions(QuestionQueryFilter filters);

        Task<Question> GetQuestion(int id);

        Task InsertQuestion(Question post);

        Task<bool> UpdateQuestion(Question post);

        Task<bool> DeleteQuestion(int id);
    }
}


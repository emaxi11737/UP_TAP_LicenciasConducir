using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Infrastructure.Data;

namespace UP_TAP_LicenciasConducir.Infrastructure.Repositories
{
    public class QuizRepository : BaseRepository<Quiz>, IQuizRepository
    {
        public QuizRepository(LicenciasConducirDataContext context) : base(context)
        {
        }

        public IEnumerable<Quiz> GetAllInclude()
        {

            return _entities
                .Include(x => x.QuizQuestions)
                .ThenInclude(x=> x.Answer)
                .Include(x => x.QuizQuestions)
                .ThenInclude(x=> x.Question)
                .ThenInclude(x=> x.Answer)
                .AsEnumerable();
        }

    }
}


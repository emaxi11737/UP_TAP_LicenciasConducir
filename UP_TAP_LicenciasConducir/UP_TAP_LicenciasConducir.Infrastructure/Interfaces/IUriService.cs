using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.QueryFilters;

namespace UP_TAP_LicenciasConducir.Infrastructure.Services
{
    public interface IUriService
    {
        Uri GetQuestionPaginationUri(QuestionQueryFilter filter, string actionUrl);
    }
}

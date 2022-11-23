using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities.Intermediates;

namespace UP_TAP_LicenciasConducir.Core.DTOs
{
    public class QuizQuestionDto
    {
        public int Id { get; set; }
        public QuestionDto Question { get; set; }

    }
}

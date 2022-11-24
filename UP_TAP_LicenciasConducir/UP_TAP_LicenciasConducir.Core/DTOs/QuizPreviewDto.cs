using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities.Intermediates;

namespace UP_TAP_LicenciasConducir.Core.DTOs
{
    public class QuizPreviewDto
    {
        public int ExamId { get; set; }
        public int Id { get; set; }

        public List<QuizQuestionDto> QuizQuestions { get; set; }

    }
}

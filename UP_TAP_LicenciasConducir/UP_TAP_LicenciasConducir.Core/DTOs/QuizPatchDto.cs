using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities;

namespace UP_TAP_LicenciasConducir.Core.DTOs
{
    public class QuizPatchDto
    {
        public string AccessPassword { get; set; }
        public List<QuizQuestionPatchDto> QuizQuestions { get; set; }
    }
}

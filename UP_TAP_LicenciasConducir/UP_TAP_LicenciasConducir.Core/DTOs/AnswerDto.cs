using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities;

namespace UP_TAP_LicenciasConducir.Core.DTOs
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsRight { get; set; }
        public int QuestionId { get; set; }

    }
}

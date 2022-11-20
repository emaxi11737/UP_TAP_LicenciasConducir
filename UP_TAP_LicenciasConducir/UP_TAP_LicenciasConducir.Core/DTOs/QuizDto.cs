using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_TAP_LicenciasConducir.Core.DTOs
{
    public class QuizDto
    {
        public int Id { get; set; }
        public string AccessPassword { get; set; }
        public DateTime PasswordExpirationDate { get; set; }
        public int ExamId { get; set; }
    }
}

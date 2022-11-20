using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities.Intermediates;

namespace UP_TAP_LicenciasConducir.Core.Entities
{
    public class Quiz : BaseEntity
    {
        public string AccessPassword { get; set; }
        public DateTime PasswordExpirationDate { get; set; }
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public List<QuizQuestion> QuizQuestions { get; set; }

    }
}

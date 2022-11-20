using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities.Intermediates;

namespace UP_TAP_LicenciasConducir.Core.Entities
{
    public class Answer : BaseEntity
    {
        public string Description { get; set; }
        public bool IsRight { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public List<QuizQuestion> QuizQuestions { get; set; }


    }
}

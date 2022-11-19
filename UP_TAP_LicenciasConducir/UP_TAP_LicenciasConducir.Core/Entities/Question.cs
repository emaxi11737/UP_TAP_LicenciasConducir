using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities.Intermediates;

namespace UP_TAP_LicenciasConducir.Core.Entities
{
    public class Question : BaseEntity
    {
        public string Description { get; set; }
        public virtual ICollection<Answer> Answer { get; set; }
        public List<Quiz> Quizzes { get; set; }
        public List<QuizQuestion> QuizQuestions { get; set; }


    }
}

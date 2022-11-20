using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_TAP_LicenciasConducir.Core.Entities.Intermediates
{
    public class QuizQuestion : BaseEntity
    {
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }

    }
}

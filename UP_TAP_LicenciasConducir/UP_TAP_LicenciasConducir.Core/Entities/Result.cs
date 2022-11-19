using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_TAP_LicenciasConducir.Core.Entities
{
    public class Result : BaseEntity
    {
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public int Score { get; set; }
        public DateTime ResultDate { get; set; }
    }
}

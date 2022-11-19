using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_TAP_LicenciasConducir.Core.Entities
{
    public class MedicalRevision : BaseEntity
    {
        public DateTime RevisionDate { get; set; }
        public bool IsPassed { get; set; }
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_TAP_LicenciasConducir.Core.DTOs
{
    public class MedicalRevisionDto
    {
        public int Id { get; set; }
        public DateTime RevisionDate { get; set; }
        public bool IsPassed { get; set; }
        public int ExamId { get; set; }
    }
}

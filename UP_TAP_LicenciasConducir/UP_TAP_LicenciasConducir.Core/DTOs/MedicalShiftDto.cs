using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_TAP_LicenciasConducir.Core.DTOs
{
    public class MedicalShiftDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? MedicalRevisionId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UP_TAP_LicenciasConducir.Core.DTOs
{
    public class ExamPreviewDto
    {
        public bool UseGlasses { get; set; }
        public int Id { get; set; }
        public MedicalRevisionDto MedicalRevision { get; set; }
    }
}

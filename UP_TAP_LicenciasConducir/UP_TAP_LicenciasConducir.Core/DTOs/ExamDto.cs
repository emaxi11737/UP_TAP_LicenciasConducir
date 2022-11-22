using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UP_TAP_LicenciasConducir.Core.DTOs
{
    public class ExamDto
    {
        public bool UseGlasses { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_TAP_LicenciasConducir.Core.DTOs
{
    public class ResultDto
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime ResultDate { get; set; }
        public int ExamId { get; set; }
    }
}

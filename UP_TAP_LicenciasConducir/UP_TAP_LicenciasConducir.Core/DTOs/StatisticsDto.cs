using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_TAP_LicenciasConducir.Core.DTOs
{
    public class StatisticsDto
    {
        public int Attended { get; set; }
        public int Passed { get; set; }
        public int Failed { get; set; }
        public int Absent { get; set; }
    }
}

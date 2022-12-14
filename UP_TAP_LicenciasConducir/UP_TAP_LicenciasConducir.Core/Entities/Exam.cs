using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_TAP_LicenciasConducir.Core.Entities
{
    public class Exam : BaseEntity
    {
        public bool UseGlasses { get; set; }
        public int UserId { get; set; }
        public virtual MedicalRevision MedicalRevision { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual Security User { get; set; }

    }
}

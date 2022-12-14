using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities.Intermediates;
using UP_TAP_LicenciasConducir.Core.Enums;

namespace UP_TAP_LicenciasConducir.Core.Entities
{
    public class Security : BaseEntity
    {
        public string User { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public RoleType Role { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}

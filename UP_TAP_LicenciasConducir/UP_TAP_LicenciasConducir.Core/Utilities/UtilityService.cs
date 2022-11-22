using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Utilities.Interfaces;

namespace UP_TAP_LicenciasConducir.Core.Utilities
{
    public class UtilityService : IUtilityService
    {
        Random _rnd = new Random();

        public IEnumerable<Question> Random(IEnumerable<Question> list)
        {
            return list.OrderBy(x => _rnd.Next());
        }
        public IEnumerable<MedicalShift> Random(IEnumerable<MedicalShift> list)
        {
            return list.OrderBy(x => _rnd.Next());
        }

    }
}

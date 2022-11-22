using UP_TAP_LicenciasConducir.Core.Entities;

namespace UP_TAP_LicenciasConducir.Core.Utilities.Interfaces
{
    public interface IUtilityService
    {
        IEnumerable<Question> Random(IEnumerable<Question> list);
        IEnumerable<MedicalShift> Random(IEnumerable<MedicalShift> list);
    }
}


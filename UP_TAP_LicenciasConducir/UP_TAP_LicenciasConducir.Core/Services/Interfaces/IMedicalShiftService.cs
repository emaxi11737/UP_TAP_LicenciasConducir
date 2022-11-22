using UP_TAP_LicenciasConducir.Core.Entities;

namespace UP_TAP_LicenciasConducir.Core.Services.Interfaces
{
    public interface IMedicalShiftService
    {
        Task<MedicalShift> GetRandomMedicalShift();
        public Task<bool> UpdateMedicalShift(MedicalShift medicalShift);
    }
}


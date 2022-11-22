using UP_TAP_LicenciasConducir.Core.CustomEntities;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.QueryFilters;

namespace UP_TAP_LicenciasConducir.Core.Services.Interfaces
{
    public interface IMedicalRevisionService
    {
        MedicalRevision GetMedicalRevisionByExamId(int examId);
        Task InsertMedicalRevision(int examId);
        Task<bool> UpdateMedicalRevision(MedicalRevision medicalRevision);
        PagedList<MedicalRevision> GetPendingMedicalRevision(QueryFilter filters);
    }
}


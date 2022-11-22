using Microsoft.Extensions.Options;
using UP_TAP_LicenciasConducir.Core.CustomEntities;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Core.QueryFilters;
using UP_TAP_LicenciasConducir.Core.Services.Interfaces;

namespace UP_TAP_LicenciasConducir.Core.Services
{
    public class MedicalRevisionService : IMedicalRevisionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMedicalShiftService _medicalShiftService;
        private readonly PaginationOptions _paginationOptions;

        public MedicalRevisionService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IMedicalShiftService medicalShiftService)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _medicalShiftService = medicalShiftService;
        }

        public MedicalRevision GetMedicalRevisionByExamId(int examId)
        {
            var medicalRevisions =  _unitOfWork.MedicalRevisionRepository.GetAll();

            return medicalRevisions.FirstOrDefault(x => x.ExamId == examId);

        }

        public async Task InsertMedicalRevision(int examId)
        {
            var medicalRevision = new MedicalRevision
            {
                ExamId = examId
            };
            await _unitOfWork.MedicalRevisionRepository.Add(medicalRevision);

            var medicalShift = await _medicalShiftService.GetRandomMedicalShift();
            await _unitOfWork.SaveChangesAsync();
            medicalShift.MedicalRevisionId = medicalRevision.Id;
            await _medicalShiftService.UpdateMedicalShift(medicalShift);
        }

        public async Task<bool> UpdateMedicalRevision(MedicalRevision medicalRevision)
        {
            var existingMedicalRevision = await _unitOfWork.MedicalRevisionRepository.GetById(medicalRevision.Id);
            existingMedicalRevision.IsPassed = medicalRevision.IsPassed;

            _unitOfWork.MedicalRevisionRepository.Update(existingMedicalRevision);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
  

        public PagedList<MedicalRevision> GetPendingMedicalRevision(QueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var medicalRevisions = _unitOfWork.MedicalRevisionRepository.GetAllPending();

            var pagedQuestions = PagedList<MedicalRevision>.Create(medicalRevisions, filters.PageNumber, filters.PageSize);
            return pagedQuestions;
        }
    }
}


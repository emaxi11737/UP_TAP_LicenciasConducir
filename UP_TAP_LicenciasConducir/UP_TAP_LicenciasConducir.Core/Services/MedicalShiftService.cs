using Microsoft.Extensions.Options;
using UP_TAP_LicenciasConducir.Core.CustomEntities;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Core.Services.Interfaces;
using UP_TAP_LicenciasConducir.Core.Utilities.Interfaces;

namespace UP_TAP_LicenciasConducir.Core.Services
{
    public class MedicalShiftService : IMedicalShiftService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly IUtilityService _utilityService;

        public MedicalShiftService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IUtilityService utilityService)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _utilityService = utilityService;
        }

        public async Task<MedicalShift> GetRandomMedicalShift()
        {
            return _utilityService.Random(_unitOfWork.MedicalShiftRepository.GetAllAvailable()).First();
        }


        public async Task<bool> UpdateMedicalShift(MedicalShift medicalShift)
        {
            var existingMedicalShift = await _unitOfWork.MedicalShiftRepository.GetById(medicalShift.Id);
            existingMedicalShift.MedicalRevisionId = medicalShift.MedicalRevisionId;

            _unitOfWork.MedicalShiftRepository.Update(existingMedicalShift);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}


using Microsoft.Extensions.Options;
using UP_TAP_LicenciasConducir.Core.CustomEntities;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Core.Services.Interfaces;

namespace UP_TAP_LicenciasConducir.Core.Services
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly IMedicalRevisionService _medicalRevisionService;
        private readonly ISecurityService _securityService;


        public ExamService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IMedicalRevisionService medicalRevisionService)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _medicalRevisionService = medicalRevisionService;
        }

        public async Task InsertExam(Exam exam)
        {
            await _unitOfWork.ExamRepository.Add(exam);
            await _unitOfWork.SaveChangesAsync();

             if (exam.UseGlasses)
             {
               await _medicalRevisionService.InsertMedicalRevision(exam.Id);
             }


        }
    }
}


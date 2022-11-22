using Microsoft.Extensions.Options;
using UP_TAP_LicenciasConducir.Core.CustomEntities;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Entities.Intermediates;
using UP_TAP_LicenciasConducir.Core.Exceptions;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Core.QueryFilters;
using UP_TAP_LicenciasConducir.Core.Services.Interfaces;

namespace UP_TAP_LicenciasConducir.Core.Services
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly IMedicalRevisionService _medicalRevisionService;

        public QuizService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IMedicalRevisionService medicalRevisionService, IQuestionService questionService)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _medicalRevisionService = medicalRevisionService;
        }

        public async Task InsertQuiz(Quiz quiz)
        {
            var checkQuiz = _unitOfWork.QuizRepository.GetAll().Where(x=> x.ExamId == quiz.ExamId);
            if (checkQuiz.Any())
            {
                throw new BusinessException("Ya se ha rendido un cuestionario para ese examen");
            }
            var medicalRevision = _medicalRevisionService.GetMedicalRevisionByExamId(quiz.ExamId);
            if (medicalRevision != null)
            {
                if ((bool)!medicalRevision?.IsPassed || medicalRevision?.IsPassed == null)
                {
                    throw new BusinessException("Usted ha fallado el examen medico o no lo ha realizado");
                }
            }

            quiz.PasswordExpirationDate = DateTime.Now.AddHours(1);

            await _unitOfWork.QuizRepository.Add(quiz);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}


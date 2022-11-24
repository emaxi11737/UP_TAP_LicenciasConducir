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
        private readonly IQuestionService _questionService;

        public QuizService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IMedicalRevisionService medicalRevisionService, IQuestionService questionService)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _medicalRevisionService = medicalRevisionService;
            _questionService = questionService;
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
                if (medicalRevision?.IsPassed == null)
                {
                    throw new BusinessException("Usted no ha realizado el examen medico");
                }
                if ((bool)!medicalRevision?.IsPassed)
                {
                    throw new BusinessException("Usted ha fallado el examen medico");
                }
            }

            quiz.PasswordExpirationDate = DateTime.Now.AddHours(1);

            var queryFilter = new QueryFilter
            {
                PageNumber = 1,
                PageSize = 10
            };
    

            await _unitOfWork.QuizRepository.Add(quiz);
            await _unitOfWork.SaveChangesAsync();

            var questions = _questionService.GetRandomQuestions(queryFilter).Select(x =>
                new QuizQuestion()
                {
                    QuestionId = x.Id,
                    QuizId = quiz.Id,
                }
            ).ToList();


            await _unitOfWork.QuizQuestionRepository.BulkInsert(questions);
            await _unitOfWork.SaveChangesAsync();

           


        }


        public async Task<bool> UpdateQuiz(Quiz quiz)
        {
            var existingQuiz = await _unitOfWork.QuizRepository.GetById(quiz.Id);

            existingQuiz.PasswordExpirationDate = quiz.PasswordExpirationDate;

            quiz.QuizQuestions.ForEach(x=> x.QuizId = existingQuiz.Id);

            _unitOfWork.QuizRepository.Update(existingQuiz);
            await _unitOfWork.QuizQuestionRepository.BulkUpdate(quiz.QuizQuestions);

            await _unitOfWork.SaveChangesAsync();
            return true;
        }


        public Quiz GetQuiz(int id)
        {
            return _unitOfWork.QuizRepository.GetAllInclude().First(x => x.Id == id);
        }
    }
}


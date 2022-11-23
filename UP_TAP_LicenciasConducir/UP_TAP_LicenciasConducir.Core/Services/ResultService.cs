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
    public class ResultService : IResultService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly IQuizService _quizService;
        public ResultService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IQuizService quizService)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _quizService = quizService;
        }


        public PagedList<Result> GetResults(QueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var results = _unitOfWork.ResultRepository.GetAll();

            var pagedQuestions = PagedList<Result>.Create(results, filters.PageNumber, filters.PageSize);
            return pagedQuestions;
        }


        public async Task<Result> InsertResult(int quizId)
        {
            var quiz = _quizService.GetQuiz(quizId);
            var score = quiz.QuizQuestions.Count(x => x.Answer.IsRight);
            var result = new Result
            {
                ExamId = quiz.ExamId,
                ResultDate = DateTime.Now,
                Score = score
            };
            await _unitOfWork.ResultRepository.Add(result);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}


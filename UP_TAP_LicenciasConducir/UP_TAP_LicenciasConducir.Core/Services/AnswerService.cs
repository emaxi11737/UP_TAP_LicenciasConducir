using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using UP_TAP_LicenciasConducir.Core.CustomEntities;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Exceptions;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Core.QueryFilters;
using UP_TAP_LicenciasConducir.Core.Services.Interfaces;

namespace UP_TAP_LicenciasConducir.Core.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public AnswerService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Answer> GetAnswer(int id)
        {
            return await _unitOfWork.AnswerRepository.GetById(id);
        }

        public PagedList<Answer> GetAnswers(QueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var answers = _unitOfWork.AnswerRepository.GetAll();

            var pagedAnswers = PagedList<Answer>.Create(answers, filters.PageNumber, filters.PageSize);
            return pagedAnswers;
        }

        public async Task InsertAnswer(Answer answer)
        {

            var question = await _unitOfWork.QuestionRepository.GetById(answer.QuestionId);
            if (question == null)
                throw new BusinessException("Question doesn't exist");

            await _unitOfWork.AnswerRepository.Add(answer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateAnswer(Answer answer)
        {
            var existingAnswer = await _unitOfWork.AnswerRepository.GetById(answer.Id);
            existingAnswer.Description = answer.Description;

            _unitOfWork.AnswerRepository.Update(existingAnswer);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAnswer(int id)
        {
            await _unitOfWork.AnswerRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}


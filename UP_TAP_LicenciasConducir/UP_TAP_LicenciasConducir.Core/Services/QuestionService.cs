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

namespace UP_TAP_LicenciasConducir.Core.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public QuestionService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Question> GetQuestion(int id)
        {
            return await _unitOfWork.QuestionRepository.GetById(id);
        }

        public PagedList<Question> GetQuestions(QuestionQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var posts = _unitOfWork.QuestionRepository.GetAll();

            var pagedQuestions = PagedList<Question>.Create(posts, filters.PageNumber, filters.PageSize);
            return pagedQuestions;
        }

        public async Task InsertQuestion(Question post)
        {

            await _unitOfWork.QuestionRepository.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateQuestion(Question post)
        {
            var existingQuestion = await _unitOfWork.QuestionRepository.GetById(post.Id);
            existingQuestion.Description = post.Description;

            _unitOfWork.QuestionRepository.Update(existingQuestion);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteQuestion(int id)
        {
            await _unitOfWork.QuestionRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Entities.Intermediates;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Infrastructure.Data;

namespace UP_TAP_LicenciasConducir.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LicenciasConducirDataContext _context;
        private readonly IQuestionRepository _questionRepository;
        private readonly IRepository<Answer> _answerRepository;
        private readonly IRepository<Exam> _examRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly IRepository<QuizQuestion> _quizQuestionRepository;
        private readonly IRepository<Result> _resultRepository;
        private readonly IMedicalRevisionRepository _medicalRevisionRepository;
        private readonly IMedicalShiftRepository _medicalShiftRepository;
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(LicenciasConducirDataContext context)
        {
            _context = context;
        }
        public IQuestionRepository QuestionRepository => _questionRepository ?? new QuestionRepository(_context);
        public IRepository<Answer> AnswerRepository => _answerRepository ?? new BaseRepository<Answer>(_context);
        public IRepository<Exam> ExamRepository => _examRepository ?? new BaseRepository<Exam>(_context);
        public IQuizRepository QuizRepository => _quizRepository ?? new QuizRepository(_context);
        public IRepository<QuizQuestion> QuizQuestionRepository => _quizQuestionRepository ?? new BaseRepository<QuizQuestion>(_context);
        public IRepository<Result> ResultRepository => _resultRepository ?? new BaseRepository<Result>(_context);
        public IMedicalRevisionRepository MedicalRevisionRepository => _medicalRevisionRepository ?? new MedicalRevisionRepository(_context);
        public IMedicalShiftRepository MedicalShiftRepository => _medicalShiftRepository ?? new MedicalShiftRepository(_context);
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Infrastructure.Data;

namespace UP_TAP_LicenciasConducir.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LicenciasConducirDataContext _context;
        private readonly IQuestionRepository _questionRepository;
        private readonly IRepository<Answer> _answerRepository;
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(LicenciasConducirDataContext context)
        {
            _context = context;
        }
        public IQuestionRepository QuestionRepository => _questionRepository ?? new QuestionRepository(_context);
        public IRepository<Answer> AnswerRepository => _answerRepository ?? new BaseRepository<Answer>(_context);
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


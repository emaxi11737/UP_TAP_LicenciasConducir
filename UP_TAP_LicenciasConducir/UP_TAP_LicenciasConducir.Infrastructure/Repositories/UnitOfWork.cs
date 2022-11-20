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
        private readonly IRepository<Question> _questionRepository;

        public UnitOfWork(LicenciasConducirDataContext context)
        {
            _context = context;
        }
        public IRepository<Question> QuestionRepository => _questionRepository ?? new BaseRepository<Question>(_context);

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


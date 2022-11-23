using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Entities.Intermediates;

namespace UP_TAP_LicenciasConducir.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IQuestionRepository QuestionRepository { get; }
        IRepository<Answer> AnswerRepository { get; }
        IRepository<Exam> ExamRepository { get; }
        IRepository<QuizQuestion> QuizQuestionRepository { get; }
        IRepository<Result> ResultRepository { get; }
        IQuizRepository QuizRepository { get; }
        IMedicalRevisionRepository MedicalRevisionRepository { get; }
        IMedicalShiftRepository MedicalShiftRepository { get; }
        ISecurityRepository SecurityRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}

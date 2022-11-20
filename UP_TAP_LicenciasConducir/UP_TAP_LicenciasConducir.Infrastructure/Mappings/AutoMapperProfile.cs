using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UP_TAP_LicenciasConducir.Core.DTOs;
using UP_TAP_LicenciasConducir.Core.Entities;

namespace UP_TAP_LicenciasConducir.Infrastructure.Mappings
{
    public class GlobalExceptionFilter : Profile
    {
        public GlobalExceptionFilter()
        {
            CreateMap<Answer, AnswerDto>();
            CreateMap<AnswerDto, Answer>();
            CreateMap<ExamDto, Exam>();
            CreateMap<Exam, ExamDto>();
            CreateMap<MedicalRevision, MedicalRevisionDto>();
            CreateMap<MedicalRevisionDto, MedicalRevision>();
            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionDto, Question>();
            CreateMap<Quiz, QuizDto>();
            CreateMap<QuizDto, Quiz>();
            CreateMap<Result, ResultDto>();
            CreateMap<ResultDto, Result>();
        }
    }
}

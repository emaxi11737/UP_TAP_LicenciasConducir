using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UP_TAP_LicenciasConducir.Core.DTOs;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Entities.Intermediates;

namespace UP_TAP_LicenciasConducir.Infrastructure.Mappings
{
    public class GlobalExceptionFilter : Profile
    {
        public GlobalExceptionFilter()
        {
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<AnswerPatchDto, Answer>();
            CreateMap<ExamDto, Exam>().ReverseMap();
            CreateMap<Exam, ExamPreviewDto>();
            CreateMap<MedicalRevision, MedicalRevisionDto>().ReverseMap();
            CreateMap<MedicalRevisionPatchDto, MedicalRevision>();
            CreateMap<MedicalShift, MedicalShiftDto>().ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<QuestionPatchDto, Question>();
            CreateMap<Quiz, QuizDto>().ReverseMap();
            CreateMap<QuizPatchDto, Quiz>();
            CreateMap<Quiz, QuizPreviewDto>();
            CreateMap<QuizQuestion, QuizQuestionDto>().ReverseMap();
            CreateMap<QuizQuestionPatchDto, QuizQuestion>();
            CreateMap<Result, ResultDto>().ReverseMap();
            CreateMap<Security, SecurityDto>().ReverseMap();
        }
    }
}

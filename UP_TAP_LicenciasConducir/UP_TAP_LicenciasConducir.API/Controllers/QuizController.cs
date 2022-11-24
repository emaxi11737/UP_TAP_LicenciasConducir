using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UP_TAP_LicenciasConducir.API.Responses;
using UP_TAP_LicenciasConducir.Core.DTOs;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Enums;
using UP_TAP_LicenciasConducir.Core.Exceptions;
using UP_TAP_LicenciasConducir.Core.Services;
using UP_TAP_LicenciasConducir.Core.Services.Interfaces;
using UP_TAP_LicenciasConducir.Infrastructure.Services.Interfaces;

namespace UP_TAP_LicenciasConducir.API.Controllers
{
    [Authorize(Roles = nameof(RoleType.Consumer))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IPasswordService _passwordService;
        private readonly IResultService _resultService;
        private readonly IExamService _examService;

        public QuizController(IQuizService quizService, IMapper mapper, IUriService uriService, IPasswordService passwordService, IResultService resultService, IExamService examService)
        {
            _quizService = quizService;
            _mapper = mapper;
            _uriService = uriService;
            _passwordService = passwordService;
            _resultService = resultService;
            _examService = examService;
        }

        [HttpPost]
        public async Task<IActionResult> Quiz(QuizDto quizDto)
        {
            var quiz = _mapper.Map<Quiz>(quizDto);

            quiz.AccessPassword = _passwordService.Hash(quiz.AccessPassword);

            await _quizService.InsertQuiz(quiz);

            var quizPreviewDto = _mapper.Map<QuizPreviewDto>(quiz);
            var response = new ApiResponse<QuizPreviewDto>(quizPreviewDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz(int id)
        {
            var quiz = _quizService.GetQuiz(id);
            var quizDto = _mapper.Map<QuizPreviewDto>(quiz);
            var response = new ApiResponse<QuizPreviewDto>(quizDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, QuizPatchDto quizPatchDto)
        {
            var quiz = _quizService.GetQuiz(id);
            var validation = await IsValidPassword(quiz, quizPatchDto);
            if (!validation.Item1)
                throw new BusinessException("Invalid access password");


            if (quiz.PasswordExpirationDate < DateTime.Now)
                throw new BusinessException("Password Expired at " + quiz.PasswordExpirationDate.ToString("dd/MM/yyyy hh:mm"));

            quiz = _mapper.Map<Quiz>(quizPatchDto);

            quiz.Id = id;
            quiz.PasswordExpirationDate = DateTime.Now;


            var quizCreated = await _quizService.UpdateQuiz(quiz);

            if (!quizCreated)
                return BadRequest();


            return Ok();
        }

        private async Task<(bool, Quiz)> IsValidPassword(Quiz quiz, QuizPatchDto quizDto)
        {
            var isValid = _passwordService.Check(quiz.AccessPassword, quizDto.AccessPassword);
            return (isValid, quiz);
        }

    }
}


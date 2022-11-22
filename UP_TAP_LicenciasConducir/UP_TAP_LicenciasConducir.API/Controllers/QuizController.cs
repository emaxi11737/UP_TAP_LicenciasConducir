using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UP_TAP_LicenciasConducir.API.Responses;
using UP_TAP_LicenciasConducir.Core.DTOs;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Enums;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Core.Services;
using UP_TAP_LicenciasConducir.Core.Services.Interfaces;
using UP_TAP_LicenciasConducir.Infrastructure.Services.Interfaces;

namespace UP_TAP_LicenciasConducir.API.Controllers
{
    //[Authorize(Roles = nameof(RoleType.Consumer))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IPasswordService _passwordService;

        public QuizController(IQuizService quizService, IMapper mapper, IUriService uriService, IPasswordService passwordService)
        {
            _quizService = quizService;
            _mapper = mapper;
            _uriService = uriService;
            _passwordService = passwordService; 
        }


        [HttpPost]
        public async Task<IActionResult> Quiz(QuizDto quizDto)
        {
            var quiz = _mapper.Map<Quiz>(quizDto);

            quiz.AccessPassword = _passwordService.Hash(quiz.AccessPassword);

            await _quizService.InsertQuiz(quiz);

            quizDto = _mapper.Map<QuizDto>(quiz);
            var response = new ApiResponse<QuizDto>(quizDto);
            return Ok(response);
        }
    }
}


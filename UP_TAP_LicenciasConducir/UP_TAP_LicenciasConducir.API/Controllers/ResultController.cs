using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using UP_TAP_LicenciasConducir.API.Responses;
using UP_TAP_LicenciasConducir.Core.CustomEntities;
using UP_TAP_LicenciasConducir.Core.DTOs;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Enums;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Core.QueryFilters;
using UP_TAP_LicenciasConducir.Core.Services;
using UP_TAP_LicenciasConducir.Core.Services.Interfaces;
using UP_TAP_LicenciasConducir.Infrastructure.Services;
using UP_TAP_LicenciasConducir.Infrastructure.Services.Interfaces;

namespace UP_TAP_LicenciasConducir.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;
        private readonly IExamService _examService;
        private readonly IQuizService _quizService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public ResultController(IResultService resultService, IMapper mapper, IUriService uriService, IExamService examService, IQuizService quizService)
        {
            _resultService = resultService;
            _mapper = mapper;
            _uriService = uriService;
            _examService = examService;
            _quizService = quizService;
        }
        /// <summary>
        /// Retrieve all Results
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [Authorize(Roles = nameof(RoleType.Administrator))]
        [HttpGet(Name = nameof(GetResults))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<StatisticsDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetResults([FromQuery] QueryFilter filters)
        {
            var results = _resultService.GetResults(filters);

            var statisticsDto = new StatisticsDto()
            {
                Attended = results.Count,
                Passed = results.Count(x => x.Score >= 8),
                Failed = results.Count(x => x.Score < 8),
                Absent = results.Count(x => x.Score == 0)


            };

            var response = new ApiResponse<StatisticsDto>(statisticsDto);

            return Ok(response);
        }

        [Authorize(Roles = nameof(RoleType.Consumer))]
        [HttpPost]
        public async Task<IActionResult> Result(int quizId)
        {
            var quiz = _quizService.GetQuiz(quizId);
            var result = await _resultService.InsertResult(quiz.Id);
            if (result.Score < 8)
            {
                var exam = await _examService.GetExam(quiz.ExamId);
                exam.Id = 0;
                await _examService.InsertExam(exam);
            }
            var resultDto = _mapper.Map<ResultDto>(result);
            var response = new ApiResponse<ResultDto>(resultDto);
            return Ok(response);
        }

    }
}


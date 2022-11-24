using AutoMapper;
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
using UP_TAP_LicenciasConducir.Infrastructure.Services.Interfaces;

namespace UP_TAP_LicenciasConducir.API.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public QuestionController(IQuestionService questionService, IMapper mapper, IUriService uriService)
        {
            _questionService = questionService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all Questions
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetQuestions))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<QuestionDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetQuestions([FromQuery] QueryFilter filters)
        {
            var Questions = _questionService.GetQuestions(filters);
            var QuestionsDtos = _mapper.Map<IEnumerable<QuestionDto>>(Questions);

            var metadata = new Metadata
            {
                TotalCount = Questions.TotalCount,
                PageSize = Questions.PageSize,
                CurrentPage = Questions.CurrentPage,
                TotalPages = Questions.TotalPages,
                HasNextPage = Questions.HasNextPage,
                HasPreviousPage = Questions.HasPreviousPage,
                NextPageUrl = _uriService.GetPaginationUri(filters, Url.RouteUrl(nameof(GetQuestions))).ToString(),
                PreviousPageUrl = _uriService.GetPaginationUri(filters, Url.RouteUrl(nameof(GetQuestions))).ToString()
            };

            var response = new ApiResponse<IEnumerable<QuestionDto>>(QuestionsDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        /// <summary>
        /// Retrieve all Questions
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet("Random")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<QuestionDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetRandomQuestions([FromQuery] QueryFilter filters)
        {
            var Questions = _questionService.GetRandomQuestions(filters);
            var QuestionsDtos = _mapper.Map<IEnumerable<QuestionDto>>(Questions);

            var metadata = new Metadata
            {
                TotalCount = Questions.TotalCount,
                PageSize = Questions.PageSize,
                CurrentPage = Questions.CurrentPage,
                TotalPages = Questions.TotalPages,
                HasNextPage = Questions.HasNextPage,
                HasPreviousPage = Questions.HasPreviousPage,
                NextPageUrl = _uriService.GetPaginationUri(filters, Url.RouteUrl(nameof(GetRandomQuestions))).ToString(),
                PreviousPageUrl = _uriService.GetPaginationUri(filters, Url.RouteUrl(nameof(GetRandomQuestions))).ToString()
            };

            var response = new ApiResponse<IEnumerable<QuestionDto>>(QuestionsDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var Question = await _questionService.GetQuestion(id);
            var QuestionDto = _mapper.Map<QuestionDto>(Question);
            var response = new ApiResponse<QuestionDto>(QuestionDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Question(QuestionDto QuestionDto)
        {
            var Question = _mapper.Map<Question>(QuestionDto);

            await _questionService.InsertQuestion(Question);

            QuestionDto = _mapper.Map<QuestionDto>(Question);
            var response = new ApiResponse<QuestionDto>(QuestionDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, QuestionPatchDto QuestionPatchDto)
        {
            var Question = _mapper.Map<Question>(QuestionPatchDto);
            Question.Id = id;

            var result = await _questionService.UpdateQuestion(Question);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _questionService.DeleteQuestion(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}


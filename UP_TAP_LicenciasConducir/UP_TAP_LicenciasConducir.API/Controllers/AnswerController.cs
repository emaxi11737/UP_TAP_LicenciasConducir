using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Net;
using UP_TAP_LicenciasConducir.API.Responses;
using UP_TAP_LicenciasConducir.Core.CustomEntities;
using UP_TAP_LicenciasConducir.Core.DTOs;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Core.QueryFilters;
using UP_TAP_LicenciasConducir.Infrastructure.Services;

namespace UP_TAP_LicenciasConducir.API.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _questionService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public AnswerController(IAnswerService questionService, IMapper mapper, IUriService uriService)
        {
            _questionService = questionService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all Answers
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetAnswers))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<AnswerDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetAnswers([FromQuery] QueryFilter filters)
        {
            var Answers = _questionService.GetAnswers(filters);
            var AnswersDtos = _mapper.Map<IEnumerable<AnswerDto>>(Answers);

            var metadata = new Metadata
            {
                TotalCount = Answers.TotalCount,
                PageSize = Answers.PageSize,
                CurrentPage = Answers.CurrentPage,
                TotalPages = Answers.TotalPages,
                HasNextPage = Answers.HasNextPage,
                HasPreviousPage = Answers.HasPreviousPage,
                NextPageUrl = _uriService.GetPaginationUri(filters, Url.RouteUrl(nameof(GetAnswers))).ToString(),
                PreviousPageUrl = _uriService.GetPaginationUri(filters, Url.RouteUrl(nameof(GetAnswers))).ToString()
            };

            var response = new ApiResponse<IEnumerable<AnswerDto>>(AnswersDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswer(int id)
        {
            var Answer = await _questionService.GetAnswer(id);
            var AnswerDto = _mapper.Map<AnswerDto>(Answer);
            var response = new ApiResponse<AnswerDto>(AnswerDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, AnswerPatchDto AnswerPatchDto)
        {
            var Answer = _mapper.Map<Answer>(AnswerPatchDto);
            Answer.Id = id;

            var result = await _questionService.UpdateAnswer(Answer);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}


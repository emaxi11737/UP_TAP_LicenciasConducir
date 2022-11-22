using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UP_TAP_LicenciasConducir.API.Responses;
using UP_TAP_LicenciasConducir.Core.DTOs;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Enums;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Core.Services.Interfaces;
using UP_TAP_LicenciasConducir.Infrastructure.Services.Interfaces;

namespace UP_TAP_LicenciasConducir.API.Controllers
{
    //[Authorize(Roles = nameof(RoleType.Consumer))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public ExamController(IExamService examService, IMapper mapper, IUriService uriService)
        {
            _examService = examService;
            _mapper = mapper;
            _uriService = uriService;
        }

        [Authorize(Roles = nameof(RoleType.Consumer))]
        [HttpPost]
        public async Task<IActionResult> Exam(ExamDto examDto)
        {
            examDto.UserId = GetUserId();

            var exam = _mapper.Map<Exam>(examDto);

            await _examService.InsertExam(exam);

            examDto = _mapper.Map<ExamDto>(exam);
            var response = new ApiResponse<ExamDto>(examDto);
            return Ok(response);
        }
        protected int GetUserId()
        {
            return int.Parse(this.User.Claims.First(i => i.Type == "UserId").Value);
        }

    }
}


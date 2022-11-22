using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;
using UP_TAP_LicenciasConducir.API.Responses;
using UP_TAP_LicenciasConducir.Core.CustomEntities;
using UP_TAP_LicenciasConducir.Core.DTOs;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Enums;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Core.QueryFilters;
using UP_TAP_LicenciasConducir.Core.Services;
using UP_TAP_LicenciasConducir.Core.Services.Interfaces;
using UP_TAP_LicenciasConducir.Infrastructure.Services.Interfaces;

namespace UP_TAP_LicenciasConducir.API.Controllers
{
    [Authorize(Roles = nameof(RoleType.Doctor))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRevisionController : ControllerBase
    {
        private readonly IMedicalRevisionService _medicalRevisionService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public MedicalRevisionController(IMedicalRevisionService medicalRevisionService, IMapper mapper, IUriService uriService)
        {
            _medicalRevisionService = medicalRevisionService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all MedicalRevisions
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetMedicalRevisions))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<MedicalRevisionDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetMedicalRevisions([FromQuery] QueryFilter filters)
        {
            var MedicalRevisions = _medicalRevisionService.GetPendingMedicalRevision(filters);
            var MedicalRevisionsDtos = _mapper.Map<IEnumerable<MedicalRevisionDto>>(MedicalRevisions);

            var metadata = new Metadata
            {
                TotalCount = MedicalRevisions.TotalCount,
                PageSize = MedicalRevisions.PageSize,
                CurrentPage = MedicalRevisions.CurrentPage,
                TotalPages = MedicalRevisions.TotalPages,
                HasNextPage = MedicalRevisions.HasNextPage,
                HasPreviousPage = MedicalRevisions.HasPreviousPage,
                NextPageUrl = _uriService.GetPaginationUri(filters, Url.RouteUrl(nameof(GetMedicalRevisions))).ToString(),
                PreviousPageUrl = _uriService.GetPaginationUri(filters, Url.RouteUrl(nameof(GetMedicalRevisions))).ToString()
            };

            var response = new ApiResponse<IEnumerable<MedicalRevisionDto>>(MedicalRevisionsDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, MedicalRevisionPatchDto medicalRevisionPatchDto)
        {
            var medicalRevision = _mapper.Map<MedicalRevision>(medicalRevisionPatchDto);
            medicalRevision.Id = id;

            var result = await _medicalRevisionService.UpdateMedicalRevision(medicalRevision);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}


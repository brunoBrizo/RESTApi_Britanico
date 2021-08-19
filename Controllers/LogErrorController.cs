using AutoMapper;
using britanicoCore.DTO;
using britanicoCore.Interfaces;
using britanicoCore.Modelo;
using britanicoCore.QueryFilters;
using britanicoCore.Tools;
using britanicoDb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace britanicoApi.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LogErrorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogErrorService _service;
        private readonly IUriService _uriService;

        public LogErrorController(ILogErrorService logErrorService, IMapper mapper, IUriService uriService)
        {
            this._mapper = mapper;
            this._service = logErrorService;
            this._uriService = uriService;
        }

        [HttpGet(Name = nameof(GetLogs))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<LogErrorDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetLogs([FromQuery] LogErrorQueryFilter logQuery)
        {
            var logs = _service.GetAll(logQuery);
            var logsDto = _mapper.Map<IEnumerable<LogErrorDto>>(logs);

            var metada = new Metadata
            {
                CurrentPage = logs.CurrentPage,
                HasNextPage = logs.HasNextPage,
                HasPreviousPage = logs.HasPreviousPage,
                PageSize = logs.PageSize,
                TotalCount = logs.Count,
                TotalPages = logs.TotalPages,
                NextPageUrl = _uriService.GetLogErrorPaginationUri(logQuery, Url.RouteUrl(nameof(GetLogs))).ToString(),
                PreviousPageUrl = _uriService.GetLogErrorPaginationUri(logQuery, Url.RouteUrl(nameof(GetLogs))).ToString()
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metada));

            return Ok(logsDto);
        }

        [HttpGet("{id}", Name = "GetLogById")]
        public async Task<IActionResult> GetLogById(int id)
        {
            var log = await _service.GetById(id);
            if (log == null)
            {
                return NotFound();
            }
            else
            {
                var logDto = _mapper.Map<LogErrorDto>(log);
                return Ok(logDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertLog([FromBody] LogErrorDto logDto)
        {
            try
            {
                var logAux = _mapper.Map<LogError>(logDto);
                await _service.InsertLog(logAux);
                var newLog = _mapper.Map<LogErrorDto>(logAux);
                return CreatedAtRoute(nameof(GetLogById), new { Id = logAux.Id }, newLog);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{ id }")]
        public async Task<IActionResult> UpdateLog(int id, [FromBody] LogErrorDto logDto)
        {
            var log = await _service.GetById(id);
            if (log == null)
            {
                return NotFound();
            }

            _mapper.Map(logDto, log);

            await _service.UpdateLog(log);
            return Ok(log);
        }


        [HttpDelete("{ id }")]
        public async Task<IActionResult> DeleteLog(int id)
        {
            await _service.DeleteLog(id);
            return Ok();
        }

    }
}

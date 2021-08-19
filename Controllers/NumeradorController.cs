using AutoMapper;
using britanicoCore.Interfaces;
using britanicoCore.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace britanicoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NumeradorController : ControllerBase
    {
        private readonly INumeradorService _service;
        private readonly IMapper _mapper;

        public NumeradorController(INumeradorService service, IMapper mapper)
        {
            this._mapper = mapper;
            this._service = service;
        }


        [HttpGet("{empId:int}/{nombre}")]
        public async Task<IActionResult> GetByNombre(int empId, string nombre)
        {
            var numerador = await _service.GetByNombre(empId, nombre);
            if (numerador == null)
            {
                return NotFound();
            }
            return Ok(numerador);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Numerador numerador)
        {
            try
            {
                await _service.Insert(numerador);
                return Ok(numerador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Numerador numerador)
        {
            try
            {
                await _service.Update(numerador);
                return Ok(numerador);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}

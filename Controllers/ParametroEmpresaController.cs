using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using britanicoCore.Interfaces.Service;
using britanicoCore.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace britanicoApi.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ParametroEmpresaController : ControllerBase
    {
        private readonly IParametroEmpresaService _service;

        public ParametroEmpresaController(IParametroEmpresaService service)
        {
            this._service = service;
        }

        [HttpGet("{empId}", Name = (nameof(GetParametros)))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ParametroEmpresa>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetParametros(int empId)
        {
            try
            {
                var parametros = _service.GetAll(empId);
                return Ok(parametros);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        [HttpGet("{empId:int}/{nombre}", Name = (nameof(GetParametro)))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ParametroEmpresa))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetParametro(int empId, string nombre)
        {
            try
            {
                var parametro = await _service.GetByNombreEmpresa(empId, nombre);
                if (parametro == null)
                {
                    return NotFound();
                }
                return Ok(parametro);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ParametroEmpresa))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Insert([FromBody] ParametroEmpresa parametro)
        {
            try
            {
                await _service.Insert(parametro);
                return Ok(parametro);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ParametroEmpresa))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromBody] ParametroEmpresa parametro)
        {
            try
            {
                await _service.Update(parametro);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

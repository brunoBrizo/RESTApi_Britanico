using AutoMapper;
using britanicoCore.DTO;
using britanicoCore.Interfaces;
using britanicoCore.Modelo;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace britanicoApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _service;
        private readonly IMapper _mapper;

        public EmpresaController(IEmpresaService empresaService, IMapper mapper)
        {
            this._service = empresaService;
            this._mapper = mapper;
        }


        [HttpGet("{id}", Name = "GetEmpById")]
        public async Task<IActionResult> GetEmpById(int id)
        {
            var emp = await _service.GetById(id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                var empDto = _mapper.Map<EmpresaDto>(emp);
                return Ok(empDto);
            }



        }

        [HttpPost]
        public async Task<IActionResult> InsertEmpresa([FromBody] EmpresaDto empDto)
        {
            var empAux = _mapper.Map<Empresa>(empDto);
            await _service.InsertEmpresa(empAux);
            var newEmp = _mapper.Map<EmpresaDto>(empAux);
            return CreatedAtRoute(nameof(GetEmpById), new { Id = empAux.Id }, newEmp);
        }

        [HttpPut("{ id }")]
        public async Task<IActionResult> UpdateEmpresa(int id, [FromBody] EmpresaDto empDto)
        {
            var emp = await _service.GetById(id);
            if (emp == null)
            {
                return NotFound();
            }

            _mapper.Map(empDto, emp);

            await _service.UpdateEmpresa(emp);
            return Ok(emp);
        }



    }
}

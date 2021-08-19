using AutoMapper;
using britanicoCore.DTO;
using britanicoCore.Enumerations;
using britanicoCore.Interfaces;
using britanicoCore.Modelo;
using britanicoDb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace britanicoApi.Controllers
{
    //[Authorize(Roles = nameof(RolType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public SecurityController(ISecurityService securityService, IMapper mapper, IPasswordService passwordService)
        {
            this._securityService = securityService;
            this._mapper = mapper;
            this._passwordService = passwordService;
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] SecurityDto securityDto)
        {
            var user = _mapper.Map<Security>(securityDto);
            user.Password = _passwordService.Hash(user.Password);
            await _securityService.RegisterUser(user);

            securityDto = _mapper.Map<SecurityDto>(user);
            return Ok(securityDto);
        }



    }
}

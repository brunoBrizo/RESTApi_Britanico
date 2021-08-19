using AutoMapper;
using britanicoCore.DTO;
using britanicoCore.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace britanicoDb
{
    public class AutomapperProfile : Profile
    {


        public AutomapperProfile()
        {
            CreateMap<LogError, LogErrorDto>();
            CreateMap<LogErrorDto, LogError>();

            CreateMap<Empresa, EmpresaDto>();
            CreateMap<EmpresaDto, Empresa>();

            CreateMap<Security, SecurityDto>().ReverseMap();
        }

    }
}

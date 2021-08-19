using britanicoCore.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace britanicoCore.Interfaces
{
    public interface IEmpresaService
    {
        Task<Empresa> GetById(int id);
        Task InsertEmpresa(Empresa emp);
        Task<bool> UpdateEmpresa(Empresa emp);
    }
}

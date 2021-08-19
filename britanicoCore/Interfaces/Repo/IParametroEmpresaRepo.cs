using britanicoCore.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace britanicoCore.Interfaces.Repo
{
    public interface IParametroEmpresaRepo : IRepository<ParametroEmpresa>
    {
        Task<ParametroEmpresa> GetByNombreEmpresa(int empId, string nombre);

    }
}

using britanicoCore.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace britanicoCore.Interfaces.Service
{
    public interface IParametroEmpresaService
    {
        Task<ParametroEmpresa> GetById(int id);
        IEnumerable<ParametroEmpresa> GetAll(int empId);
        Task Update(ParametroEmpresa parametroEmpresa);
        Task Insert(ParametroEmpresa parametroEmpresa);
        Task<ParametroEmpresa> GetByNombreEmpresa(int empId, string nombre);
    }
}

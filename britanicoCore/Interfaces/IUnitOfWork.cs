using britanicoCore.Interfaces.Repo;
using britanicoCore.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace britanicoCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILogErrorRepo LogRepo { get; }
        IRepository<Empresa> EmpresaRepo { get; }
        ISecurityRepo SecurityRepo { get; }
        INumeradorRepo NumeradorRepo { get; }
        IParametroEmpresaRepo ParametroEmpresaRepo { get; }
        Task SaveChangesAsync();
        void SaveChanges();
        
    }
}

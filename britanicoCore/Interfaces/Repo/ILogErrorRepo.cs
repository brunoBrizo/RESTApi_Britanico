using britanicoCore.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace britanicoCore.Interfaces
{
    public interface ILogErrorRepo : IRepository<LogError>
    {
        Task<IEnumerable<LogError>> GetLogsByEmpresa(int empId);
    }
}

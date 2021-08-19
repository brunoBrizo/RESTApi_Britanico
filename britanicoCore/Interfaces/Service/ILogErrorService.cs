using britanicoCore.Modelo;
using britanicoCore.QueryFilters;
using britanicoCore.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace britanicoCore.Interfaces
{
    public interface ILogErrorService
    {
        PagedList<LogError> GetAll(LogErrorQueryFilter logQuery);
        Task<LogError> GetById(int id);
        Task InsertLog(LogError log);
        Task<bool> DeleteLog(int id);
        Task<bool> UpdateLog(LogError log);
    }
}

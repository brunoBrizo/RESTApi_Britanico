using britanicoCore.Exceptions;
using britanicoCore.Interfaces;
using britanicoCore.Modelo;
using britanicoCore.QueryFilters;
using britanicoCore.Tools;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace britanicoCore.Services
{
    public class LogErrorService : ILogErrorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public LogErrorService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> paginationOptions)
        {
            this._unitOfWork = unitOfWork;
            this._paginationOptions = paginationOptions.Value;
        }

        public async Task<bool> DeleteLog(int id)
        {
            await _unitOfWork.LogRepo.Delete(id);

            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public PagedList<LogError> GetAll(LogErrorQueryFilter logQuery)
        {            
            logQuery.PageNumber = logQuery.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : logQuery.PageNumber;
            logQuery.PageSize = logQuery.PageSize == 0 ? _paginationOptions.DefaultPageSize : logQuery.PageSize;

            var logs = _unitOfWork.LogRepo.GetAll();

            if (logQuery.EmpId > 0)
            {
                logs = logs.Where(l => l.EmpId == logQuery.EmpId);
            }
            if (logQuery.DateTo != null)
            {
                logs = logs.Where(l => l.Fecha <= logQuery.DateTo);  //ToShortDateString lo pasa a Date
            }
            if (logQuery.DateFrom != null)
            {
                logs = logs.Where(l => l.Fecha >= logQuery.DateFrom);
            }
            if (logQuery.StackTrace != null)
            {
                logs = logs.Where(l => l.StackTrace.Trim() == logQuery.StackTrace?.Trim());
            }

            //paginacion
            var pagedLogs = PagedList<LogError>.Create(logs, logQuery.PageNumber, logQuery.PageSize);

            return pagedLogs;
        }

        public async Task<LogError> GetById(int id)
        {
            return await _unitOfWork.LogRepo.GetById(id);
        }

        public async Task InsertLog(LogError log)
        {
            try
            {
                var emp = await _unitOfWork.EmpresaRepo.GetById(log.EmpId);
                if (emp == null)
                {
                    throw new BusinessException("No existe la empresa");
                }

                await _unitOfWork.LogRepo.Insert(log);
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<bool> UpdateLog(LogError log)
        {
            var logToUpdate = await this.GetById(log.Id);
            if (logToUpdate == null)
            {
                throw new BusinessException("No existe el log que desea actualizar.");
            }
            _unitOfWork.LogRepo.Update(log);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

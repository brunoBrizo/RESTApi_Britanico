using britanicoCore.Exceptions;
using britanicoCore.Interfaces;
using britanicoCore.Interfaces.Service;
using britanicoCore.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace britanicoCore.Services
{
    public class ParametroEmpresaService : IParametroEmpresaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParametroEmpresaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<ParametroEmpresa> GetAll(int empId)
        {
            var parametros = _unitOfWork.ParametroEmpresaRepo.GetAll();
            parametros = parametros.Where(x => x.EmpId == empId);
            return parametros;
        }

        public async Task<ParametroEmpresa> GetById(int id)
        {
            try
            {
                return await _unitOfWork.ParametroEmpresaRepo.GetById(id);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }

        }

        public async Task<ParametroEmpresa> GetByNombreEmpresa(int empId, string nombre)
        {
            try
            {
                return await _unitOfWork.ParametroEmpresaRepo.GetByNombreEmpresa(empId, nombre);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }            
        }

        public async Task Insert(ParametroEmpresa parametroEmpresa)
        {
            try
            {
                var parametro = await _unitOfWork.ParametroEmpresaRepo.GetByNombreEmpresa(parametroEmpresa.EmpId, parametroEmpresa.Nombre);
                if (parametro != null)
                {
                    throw new BusinessException("Ya existe el parametro");
                }
                await _unitOfWork.ParametroEmpresaRepo.Insert(parametroEmpresa);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        public async Task Update(ParametroEmpresa parametroEmpresa)
        {
            try
            {
                var parametro = await _unitOfWork.ParametroEmpresaRepo.GetByNombreEmpresa(parametroEmpresa.EmpId, parametroEmpresa.Nombre);
                if (parametro == null)
                {
                    throw new BusinessException("No existe el parametro");
                }

                parametro.Valor = parametroEmpresa.Valor;
                _unitOfWork.ParametroEmpresaRepo.Update(parametro);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
    }
}

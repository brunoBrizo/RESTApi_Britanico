using britanicoCore.Exceptions;
using britanicoCore.Interfaces;
using britanicoCore.Modelo;
using System;
using System.Threading.Tasks;

namespace britanicoCore.Services
{
    public class NumeradorService : INumeradorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NumeradorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Numerador> GetByNombre(int empId, string nombre)
        {
            return await _unitOfWork.NumeradorRepo.GetByNombre(empId, nombre);
        }

        public async Task Insert(Numerador numerador)
        {
            try
            {
                var existingNumerador = await this.GetByNombre(numerador.EmpId, numerador.Nombre);
                if (existingNumerador != null)
                {
                    throw new BusinessException("Ya existe el numerador");
                }

                await _unitOfWork.NumeradorRepo.Insert(numerador);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task Update(Numerador numerador)
        {
            var existingNumerador = await this.GetByNombre(numerador.EmpId, numerador.Nombre);
            if (existingNumerador == null)
            {
                throw new BusinessException("No existe el numerador");
            }
            existingNumerador.Valor = numerador.Valor;

            _unitOfWork.NumeradorRepo.Update(existingNumerador);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

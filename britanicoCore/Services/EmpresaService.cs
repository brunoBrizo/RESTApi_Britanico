using britanicoCore.Interfaces;
using britanicoCore.Modelo;
using System.Threading.Tasks;

namespace britanicoCore.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmpresaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Empresa> GetById(int id)
        {
            return await _unitOfWork.EmpresaRepo.GetById(id);
        }

        public async Task InsertEmpresa(Empresa emp)
        {
            await _unitOfWork.EmpresaRepo.Insert(emp);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateEmpresa(Empresa emp)
        {
            _unitOfWork.EmpresaRepo.Update(emp);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

using britanicoCore.Interfaces;
using britanicoCore.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace britanicoCore.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unitOfWork.SecurityRepo.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(Security security)
        {
            await _unitOfWork.SecurityRepo.Insert(security);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}

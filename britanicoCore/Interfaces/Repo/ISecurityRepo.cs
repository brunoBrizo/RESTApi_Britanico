using britanicoCore.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace britanicoCore.Interfaces
{
    public interface ISecurityRepo : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
    }
}

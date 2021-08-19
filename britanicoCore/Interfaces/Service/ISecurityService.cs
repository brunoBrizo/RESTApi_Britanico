using britanicoCore.Modelo;
using System.Threading.Tasks;

namespace britanicoCore.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}
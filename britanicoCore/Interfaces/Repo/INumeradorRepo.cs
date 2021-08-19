using britanicoCore.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace britanicoCore.Interfaces
{
    public interface INumeradorRepo : IRepository<Numerador>
    {
        Task<Numerador> GetByNombre(int empId, string nombre);
    }
}

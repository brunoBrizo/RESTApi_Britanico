using britanicoCore.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace britanicoCore.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Insert(T obj);
        Task Delete(int id);
        void Update(T obj);
    }
}
